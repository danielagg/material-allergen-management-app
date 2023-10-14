using MediatR;

namespace MAM.Materials.UseCases.GetMaterialDetails;

public class GetMaterialDetailsQuery : IRequest<MaterialDetailsDto>
{
    public string MaterialId { get; }

    public GetMaterialDetailsQuery(string materialId)
    {
        MaterialId = materialId;
    }
}