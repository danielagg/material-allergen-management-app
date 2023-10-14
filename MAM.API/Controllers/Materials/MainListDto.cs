using MAM.Allergens.UseCases.GetAllergenClassificationOverview;
using MAM.Materials.UseCases.GetMaterialList;

namespace MAM.Controllers.Materials;

public record MainListDto(
    string Id,
    string MaterialCode,
    DateTime CreatedOn,
    string ShortName,
    string FullName,
    string MaterialType,
    bool HasAllergensByNature,
    bool HasAllergensByCrossContamination)
{
    public MainListDto(MaterialMainListDto material, AllergenClassificationOverviewDto allergen) : this(
        material.Id, material.MaterialCode, material.CreatedOn, material.ShortName, material.FullName,
        material.MaterialType,
        allergen.HasAllergensByNature, allergen.HasAllergensByCrossContamination)
    {
        
    }
}