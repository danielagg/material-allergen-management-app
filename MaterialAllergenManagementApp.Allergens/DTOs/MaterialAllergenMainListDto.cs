using MaterialAllergenManagementApp.Allergens;
using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

public record MaterialAllergenMainListDto(
    string Id,
    DateTime CreatedOn,
    IdNameModel<string> Material,
    bool AllergenByNature,
    bool AllergenByCrossContamination)
{
    public MaterialAllergenMainListDto(MaterialAllergenAggregate entity) : this(
        entity.Id,
        entity.CreatedOn,
        entity.Material,
        entity.AllergenByNature,
        entity.AllergenByCrossContamination) { }
}