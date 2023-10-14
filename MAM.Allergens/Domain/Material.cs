using LanguageExt.Common;
using MAM.Shared.Domain;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.MaterialClassification;

namespace MAM.Allergens.Domain;

public class Material : Entity
{
    public MaterialCode Code { get; private set; }
    public MaterialName Name { get; private set; }
    public MaterialType Type { get; private set; }
    public AllergenByNature AllergensByNature { get; private set; }
    public AllergenByCrossContamination AllergensByCrossContamination { get; private set; }

    // for EF - todo: double check this, if we still need a param-less ctor for EF
    protected Material()
    {
        
    }

    private Material(
        MaterialCode code,
        MaterialName name,
        MaterialType materialType,
        AllergenByNature allergensByNature,
        AllergenByCrossContamination allergensByCrossContamination
    ) : base()
    {
        Code = code;
        Name = name;
        Type = materialType;
        AllergensByNature = allergensByNature;
        AllergensByCrossContamination = allergensByCrossContamination;
    }

    public static Result<Material> Create(
        MaterialCode code,
        MaterialName name,
        MaterialType materialType,
        AllergenByNature allergensByNature,
        AllergenByCrossContamination allergensByCrossContamination
    )
    {
        return new Material(code, name, materialType, allergensByNature, allergensByCrossContamination);
    }

    // todo: these can be done better:
    public void AddNewAllergenByNature(Allergen allergen) => AllergensByNature = AllergensByNature.ExtendWith(allergen);
    public void AddNewAllergenByCrossContamination(Allergen allergen) => AllergensByCrossContamination = AllergensByCrossContamination.ExtendWith(allergen);

    public void RemoveAllergenByNature(Allergen allergen) => AllergensByNature = AllergensByNature.RemoveFrom(allergen);
    public void RemoveAllergenByCrossContamination(Allergen allergen) => AllergensByCrossContamination = AllergensByCrossContamination.RemoveFrom(allergen);
}
