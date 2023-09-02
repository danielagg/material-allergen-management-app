using MaterialAllergenManagementApp.Allergens;
using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

public record MaterialAllergenDetailsDto(
    string Id,
    DateTime CreatedOn,
    IdNameModel<string> Material,
    bool AllergenByNature,
    bool AllergenByCrossContamination)
{
    public MaterialAllergenDetailsDto(MaterialAllergenAggregate entity) : this(
        entity.Id,
        entity.CreatedOn,
        entity.Material,
        entity.AllergenByNature,
        entity.AllergenByCrossContamination) { }
}