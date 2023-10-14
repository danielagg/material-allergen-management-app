using MAM.Allergens.UseCases.GetAllergenClassificationDetails;
using MAM.Materials.UseCases.GetMaterialDetails;

namespace MAM.Controllers.Materials;

public record DetailsDto(
    string Id,
    string MaterialCode,
    string ShortMaterialName,
    string FullMaterialName,
    DateTime CreatedOn,
    List<string> AllergensByNature,
    List<string> AllergensByCrossContamination)
{
    public DetailsDto(MaterialDetailsDto material, AllergenClassificationDetailsDto allergen) : this(
        material.Id, material.MaterialCode, material.ShortMaterialName, material.FullMaterialName,
        material.CreatedOn, allergen.AllergensByNature, allergen.AllergensByCrossContamination)
    {
        
    }
}
