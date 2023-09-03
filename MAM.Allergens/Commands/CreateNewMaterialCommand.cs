using MediatR;
using MAM.Allergens.DTOs;

namespace MAM.Allergens.Commands;

public class CreateNewMaterialCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialId { get; }
    public string MaterialName { get; }
    public string MaterialTypeId { get; }
    public string UnitOfMeasureCode { get; }
    public string UnitOfMeasureName { get; }
    public decimal InitialStock { get; }
    public List<string> AllergensByNature { get; }
    public List<string> AllergensByCrossContamination{ get; }

    public CreateNewMaterialCommand(
        string materialId,
        string materialName,
        string materialTypeId,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination
    )
    {
        MaterialId = materialId;
        MaterialName = materialName;
        MaterialTypeId = materialTypeId;
        UnitOfMeasureCode = unitOfMeasureCode;
        UnitOfMeasureName = unitOfMeasureName;
        InitialStock = initialStock;
        AllergensByNature = allergensByNature;
        AllergensByCrossContamination = allergensByCrossContamination;
    }
}