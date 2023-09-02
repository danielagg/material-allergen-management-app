using MaterialAllergenManagementApp.Allergens;
using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

public record MaterialAllergenMainListDto(
    IdNameModel<string> Material,
    bool AllergenByNature,
    bool AllergenByCrossContamination)
{
    public MaterialAllergenMainListDto(MaterialAllergenAggregate entity) : this(
        entity.Material,
        entity.AllergenByNature,
        entity.AllergenByCrossContamination) { }
}