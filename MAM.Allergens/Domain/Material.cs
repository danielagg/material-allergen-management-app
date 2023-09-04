using MAM.Shared.Domain;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.MaterialClassification;
using MAM.Allergens.Domain.Inventory;
using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.Domain;

public class Material : Entity
{
    public IdNameModel<string> Identification { get; private set; }
    public MaterialType Type { get; private set; }
    public Stock Stock { get; private set; }
    public AllergenByNature AllergensByNature { get; private set; }
    public AllergenByCrossContamination AllergensByCrossContamination { get; private set; }

    // for EF - todo: double check this, if we still need a param-less ctor for EF
    protected Material()
    {
        
    }

    private Material(
        string materialId,
        string materialName,
        MaterialType materialType,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination
    ) : base()
    {
        Identification = new IdNameModel<string>(materialId, materialName);
        Type = materialType;
        Stock = Stock.CreateInitialStock(new UnitOfMeasure(unitOfMeasureCode, unitOfMeasureName), initialStock);
        AllergensByNature = AllergenByNature.Create(allergensByNature.Select(a => new Allergen(a)).ToList());
        AllergensByCrossContamination = AllergenByCrossContamination.Create(allergensByCrossContamination.Select(a => new Allergen(a)).ToList());
    }

    public static Material Create(
        string materialId,
        string materialName,
        MaterialType materialType,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination
    )
    {
        AssertInputParameterValidity(materialId, materialName, materialType, unitOfMeasureCode, unitOfMeasureName, initialStock,
            allergensByNature, allergensByCrossContamination);

        return new(materialId, materialName, materialType, unitOfMeasureCode, unitOfMeasureName, initialStock,
            allergensByNature, allergensByCrossContamination);
    }

    private static void AssertInputParameterValidity(
        string materialId,
        string materialName,
        MaterialType materialType,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination)
    {
        if(string.IsNullOrWhiteSpace(materialId))
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Material ID is mandatory");

        if(string.IsNullOrWhiteSpace(materialName))
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Material name is mandatory");

        if(materialType is null)
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Material type is mandatory");

        if(string.IsNullOrWhiteSpace(unitOfMeasureCode))
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Unit of measure code is mandatory");

        if(string.IsNullOrWhiteSpace(unitOfMeasureName))
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Unit of measure name is mandatory");

        if(initialStock < 0)
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Initial stock must be greater than or equal to 0");

        if(allergensByNature is null)
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Allergens by nature information must be specified");

        if(allergensByCrossContamination is null)
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Allergens by cross-contamination information must be specified");            
    }
}
