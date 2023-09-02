using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens;

public class MaterialAllergenAggregate : Entity
{
    public IdNameModel<string> Material { get; private set; }
    public bool AllergenByNature { get; private set;}
    public bool AllergenByCrossContamination { get; private set;}

    // for EF - todo: double check this, if we still need a param-less ctor for EF
    protected MaterialAllergenAggregate()
    {
        
    }

    private MaterialAllergenAggregate(
        string materialId,
        string materialName,
        bool allergenByNature,
        bool allergenByCrossContamination
    ) : base()
    {
        Material = new IdNameModel<string>(materialId, materialName);
        AllergenByNature = allergenByNature;
        AllergenByCrossContamination = allergenByCrossContamination;
    }

    public static MaterialAllergenAggregate Create(
        string materialId,
        string materialName,
        bool allergenByNature,
        bool allergenByCrossContamination
    )
    {
        // todo: validation
        return new(materialId, materialName, allergenByNature, allergenByCrossContamination);
    }
}
