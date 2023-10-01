using MediatR;
using MAM.Allergens.UseCases.GetMaterialDetails;

namespace MAM.Allergens.UseCases.CreateMaterial;

public class CreateNewMaterialCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialCode { get; }
    public string ShortMaterialName { get; }
    public string FullMaterialName { get; }
    public string MaterialTypeId { get; }
    public string UnitOfMeasureCode { get; }
    public string UnitOfMeasureName { get; }
    public decimal InitialStock { get; }
    public List<string> AllergensByNature { get; }
    public List<string> AllergensByCrossContamination{ get; }

    public CreateNewMaterialCommand(
        string materialCode,
        string shortMaterialName,
        string fullMaterialName,
        string materialTypeId,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination
    )
    {
        MaterialCode = materialCode;
        ShortMaterialName = shortMaterialName;
        FullMaterialName = fullMaterialName;
        MaterialTypeId = materialTypeId;
        UnitOfMeasureCode = unitOfMeasureCode;
        UnitOfMeasureName = unitOfMeasureName;
        InitialStock = initialStock;
        AllergensByNature = allergensByNature;
        AllergensByCrossContamination = allergensByCrossContamination;
    }
}