using MaterialAllergenManagementApp.Allergens;
using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

public record MaterialAllergenDetailsDto(
    IdNameModel<string> Material,
    bool AllergenByNature,
    bool AllergenByCrossContamination)
{
    public MaterialAllergenDetailsDto(MaterialAllergenAggregate entity) : this(
        entity.Material,
        entity.AllergenByNature,
        entity.AllergenByCrossContamination) { }
}