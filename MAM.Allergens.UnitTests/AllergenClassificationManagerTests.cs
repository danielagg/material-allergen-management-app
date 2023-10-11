using FluentAssertions;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.UnitTests;

public class AllergenClassificationManagerTests
{
    [Fact]
    public void TryAddAllergen_WithDuplicateAllergen_ThrowsException()
    {
        var soy = new Allergen("Soy");
        var wheat = new Allergen("Wheat");
        var existingAllergens = new[] {soy, wheat}.ToList();

        var action = () => AllergenClassificationManager.TryAdd(existingAllergens, soy);

        action
            .Should()
            .Throw<CannotAddDuplicateAllergensException>()
            .WithMessage("Cannot add duplicate allergens: the allergen 'Soy' cannot appear multiple times.");
    }
    
    [Fact]
    public void TryAddAllergen_WithLegalNewAllergen_AddsNewAllergenToCollection()
    {
        var soy = new Allergen("Soy");
        var wheat = new Allergen("Wheat");
        var existingAllergens = new[] { soy, wheat }.ToList();

        var peanuts = new Allergen("Peanuts");
        
        var result = AllergenClassificationManager.TryAdd(existingAllergens, peanuts);

        result
            .Should()
            .BeEquivalentTo(new [] { soy, wheat, peanuts });
    }
    
    [Fact]
    public void TryRemoveAllergen_WithNotAlreadyPresentAllergen_ThrowsException()
    {
        var soy = new Allergen("Soy");
        var wheat = new Allergen("Wheat");
        var existingAllergens = new[] { soy, wheat }.ToList();
        
        var peanuts = new Allergen("Peanuts");

        var action = () => AllergenClassificationManager.TryRemove(existingAllergens, peanuts);

        action
            .Should()
            .Throw<CannotRemoveNotPresentAllergensException>()
            .WithMessage("Cannot remove not present allergen: the allergen 'Peanuts' cannot be removed, as it's not present in the current set of allergens.");
    }
    
    [Fact]
    public void TryRemoveAllergen_WithAlreadyPresentAllergen_RemovesAllergenFromCollection()
    {
        var soy = new Allergen("Soy");
        var wheat = new Allergen("Wheat");
        var peanuts = new Allergen("Peanuts");
        var existingAllergens = new[] { soy, wheat, peanuts }.ToList();

        var result = AllergenClassificationManager.TryRemove(existingAllergens, peanuts);

        result
            .Should()
            .BeEquivalentTo(new [] { soy, wheat });
    }
}