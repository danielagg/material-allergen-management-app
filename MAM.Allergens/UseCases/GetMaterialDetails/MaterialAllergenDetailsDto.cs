using MAM.Allergens.Domain;

namespace MAM.Allergens.UseCases.GetMaterialDetails;

public record MaterialAllergenDetailsDto(
    string MaterialCode,
    string ShortMaterialName,
    string FullMaterialName,
    DateTime CreatedOn,
    List<string> AllergensByNature,
    List<string> AllergensByCrossContamination)
{
    public MaterialAllergenDetailsDto(Material material) : this(
        material.Code.Value,
        material.Name.ShortName,
        material.Name.FullName,
        material.CreatedOn,
        material.AllergensByNature.Allergens.Select(a => a.Name).ToList(),
        material.AllergensByCrossContamination.Allergens.Select(a => a.Name).ToList()) { }
}