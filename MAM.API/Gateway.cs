using MAM.Allergens.UseCases.GetAllergenClassificationDetails;
using MAM.Allergens.UseCases.GetAllergenClassificationOverview;
using MAM.Controllers.Materials;
using MAM.Materials.UseCases.GetMaterialDetails;
using MAM.Materials.UseCases.GetMaterialList;
using MAM.Shared.Domain;

namespace MaterialAllergenManagementApp;

public interface IGateway
{
    Task<PaginatedResult<MainListDto>> GetMaterialsMainList(int? top, int? skip);
    Task<DetailsDto> GetMaterialDetail(string materialId);
    
}

public class Gateway : IGateway
{
    private readonly IMediator _mediator;

    public Gateway(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<PaginatedResult<MainListDto>> GetMaterialsMainList(int? top, int? skip)
    {
        var materials = await _mediator.Send(new GetMaterialMainListQuery(top ?? 10, skip ?? 0));

        var materialIds = materials.Data.Select(d => d.Id);
        var allergenOverview = await _mediator.Send(new GetAllergenClassificationOverviewQuery(materialIds));

        var dtos = materials.Data.Aggregate(new List<MainListDto>(), (res, curr) =>
        {
            var allergen = allergenOverview.Single(x => x.MaterialId == curr.Id);
            res.Add(new MainListDto(curr, allergen));
            return res;
        });
        
        return PaginatedResult<MainListDto>.Create(dtos, materials.Total, materials.Skip);
    }

    public async Task<DetailsDto> GetMaterialDetail(string materialId)
    {
        var material = await _mediator.Send(new GetMaterialDetailsQuery(materialId));
        var allergens = await _mediator.Send(new GetAllergenClassificationDetailsQuery(materialId));
        
        return new DetailsDto(material, allergens);
    }
}