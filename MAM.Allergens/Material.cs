using MAM.Shared.Domain;

namespace MAM.Allergens;

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
        // todo: validation
        return new(materialId, materialName, materialType, unitOfMeasureCode, unitOfMeasureName, initialStock,
            allergensByNature, allergensByCrossContamination);
    }
}
