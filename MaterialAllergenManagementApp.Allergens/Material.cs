using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens;

public class Material : Entity
{
    public IdNameModel<string> Identification { get; private set; }
    public MaterialType Type { get; private set; }
    public bool AllergenByNature { get; private set;}
    public bool AllergenByCrossContamination { get; private set;}
    public Stock Stock { get; private set; }
    // public AllergenByNature AllergenByNature { get; private set; }
    // public AllergenByCrossContamination AllergenByCrossContamination { get; private set; }

    // for EF - todo: double check this, if we still need a param-less ctor for EF
    protected Material()
    {
        
    }

    private Material(
        string materialId,
        string materialName,
        bool allergenByNature,
        bool allergenByCrossContamination
    ) : base()
    {
        Identification = new IdNameModel<string>(materialId, materialName);
        AllergenByNature = allergenByNature;
        AllergenByCrossContamination = allergenByCrossContamination;
    }

    public static Material Create(
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
