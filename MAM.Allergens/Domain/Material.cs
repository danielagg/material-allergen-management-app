using LanguageExt.Common;
using MAM.Shared.Domain;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.MaterialClassification;
using MAM.Allergens.Domain.Inventory;
using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.Domain;

public class Material : Entity
{
    public MaterialCode Code { get; private set; }
    public MaterialName Name { get; private set; }
    public MaterialType Type { get; private set; }
    public Stock Stock { get; private set; }
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
        Stock initialStock,
        AllergenByNature allergensByNature,
        AllergenByCrossContamination allergensByCrossContamination
    ) : base()
    {
        Code = code;
        Name = name;
        Type = materialType;
        Stock = initialStock;
        AllergensByNature = allergensByNature;
        AllergensByCrossContamination = allergensByCrossContamination;
    }

    public static Result<Material> Create(
        MaterialCode code,
        MaterialName name,
        MaterialType materialType,
        Stock stock,
        AllergenByNature allergensByNature,
        AllergenByCrossContamination allergensByCrossContamination
    )
    {
        if(materialType is null)
            throw new MaterialCannotBeCreatedWithMissingMandatoryParametersException("Material type is mandatory");
        
        return new Material(code, name, materialType, stock, allergensByNature, allergensByCrossContamination);
    }

    // todo: these can be done better:
    public void AddNewAllergenByNature(Allergen allergen) => AllergensByNature = AllergensByNature.ExtendWith(allergen);
    public void AddNewAllergenByCrossContamination(Allergen allergen) => AllergensByCrossContamination = AllergensByCrossContamination.ExtendWith(allergen);

    public void RemoveAllergenByNature(Allergen allergen) => AllergensByNature = AllergensByNature.RemoveFrom(allergen);
    public void RemoveAllergenByCrossContamination(Allergen allergen) => AllergensByCrossContamination = AllergensByCrossContamination.RemoveFrom(allergen);
}
