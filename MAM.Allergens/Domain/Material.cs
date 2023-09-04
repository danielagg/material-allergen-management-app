using MAM.Shared.Domain;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.MaterialClassification;
using MAM.Allergens.Domain.Inventory;
using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.Domain;

public class Material : Entity
{
    public MaterialCode Code { get; private set; }
    public string Name { get; private set; }
    public MaterialType Type { get; private set; }
    public Stock Stock { get; private set; }
    public AllergenByNature AllergensByNature { get; private set; }
    public AllergenByCrossContamination AllergensByCrossContamination { get; private set; }

    // for EF - todo: double check this, if we still need a param-less ctor for EF
    protected Material()
    {
        
    }

    private Material(
        MaterialCode materialCode,
        string materialName,
        MaterialType materialType,
        Stock initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination
    ) : base()
    {
        Code = materialCode;
        Name = materialName;
        Type = materialType;
        Stock = initialStock;
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
        AssertInputParameterValidity(materialName, materialType, allergensByNature, allergensByCrossContamination);

        var materialCode = MaterialCode.Create(materialId);
        var unitOfMeasure = UnitOfMeasure.Create(unitOfMeasureCode, unitOfMeasureName);
        var stock = Stock.CreateInitialStock(unitOfMeasure, initialStock);

        return new(materialCode, materialName, materialType, stock, allergensByNature, allergensByCrossContamination);
    }

    private static void AssertInputParameterValidity(
        string materialName,
        MaterialType materialType,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination)
    {
        if(string.IsNullOrWhiteSpace(materialName))
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Material name is mandatory");

        if(materialType is null)
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Material type is mandatory");

        if(allergensByNature is null)
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Allergens by nature information must be specified");

        if(allergensByCrossContamination is null)
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Allergens by cross-contamination information must be specified");            
    }
}
