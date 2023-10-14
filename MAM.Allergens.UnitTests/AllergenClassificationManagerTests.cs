using MAM.Allergens.Domain;
using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.UnitTests;

public class AllergenClassificationManagerTests
{
    private const string DefaultMaterialId = "Material1";

    private readonly IndividualAllergen _soy = new("Soy");
    private readonly IndividualAllergen _wheat = new("Wheat");
    private readonly IndividualAllergen _peanuts = new("Peanuts");
    
    [Fact]
    public void AddAllergenByNature_WithDuplicateAllergen_ThrowsException()
    {
        var sut = new AllergenClassification(
            DefaultMaterialId,
            new AllergenByNature(new[] { _soy, _wheat }.ToList()),
            new AllergenByCrossContamination(new List<IndividualAllergen>()));

        var action = () => sut.AddNewAllergenByNature(_soy);

        action
            .Should()
            .Throw<CannotAddDuplicateAllergensException>()
            .WithMessage("Cannot add duplicate allergens: the allergen 'Soy' cannot appear multiple times.");
    }
    
    [Fact]
    public void AddAllergenByCrossContamination_WithDuplicateAllergen_ThrowsException()
    {
        var sut = new AllergenClassification(
            DefaultMaterialId,
            new AllergenByNature(new List<IndividualAllergen>()),
            new AllergenByCrossContamination(new[] { _soy, _wheat }.ToList()));

        var action = () => sut.AddNewAllergenByCrossContamination(_soy);

        action
            .Should()
            .Throw<CannotAddDuplicateAllergensException>()
            .WithMessage("Cannot add duplicate allergens: the allergen 'Soy' cannot appear multiple times.");
    }
    
    [Fact]
    public void AddAllergenByNature_WithLegalNewAllergen_AddsNewAllergenToCollection()
    {
        var sut = new AllergenClassification(
            DefaultMaterialId,
            new AllergenByNature(new[] { _soy, _wheat }.ToList()),
            new AllergenByCrossContamination(new[] { _soy, _wheat }.ToList()));

        sut.AddNewAllergenByNature(_peanuts);

        sut.ByNatureAllergens.Allergens
            .Should()
            .BeEquivalentTo(new [] { _soy, _wheat, _peanuts });
        
        sut.CrossContaminatingAllergens.Allergens
            .Should()
            .BeEquivalentTo(new [] { _soy, _wheat });
    }
    
    [Fact]
    public void AddAllergenByCrossContamination_WithLegalNewAllergen_AddsNewAllergenToCollection()
    {
        var sut = new AllergenClassification(
            DefaultMaterialId,
            new AllergenByNature(new[] { _soy, _wheat }.ToList()),
            new AllergenByCrossContamination(new[] { _soy, _wheat }.ToList()));

        sut.AddNewAllergenByCrossContamination(_peanuts);

        sut.ByNatureAllergens.Allergens
            .Should()
            .BeEquivalentTo(new [] { _soy, _wheat });
        
        sut.CrossContaminatingAllergens.Allergens
            .Should()
            .BeEquivalentTo(new [] { _soy, _wheat, _peanuts });
    }
    
    [Fact]
    public void RemoveAllergenByNature_WithNotAlreadyPresentAllergen_ThrowsException()
    {
        var sut = new AllergenClassification(
            DefaultMaterialId,
            new AllergenByNature(new[] { _soy, _wheat }.ToList()),
            new AllergenByCrossContamination(new List<IndividualAllergen>()));

        var action = () => sut.RemoveExistingAllergenByNature(_peanuts);

        action
            .Should()
            .Throw<CannotRemoveNotPresentAllergensException>()
            .WithMessage("Cannot remove not present allergen: the allergen 'Peanuts' cannot be removed, as it's not present in the current set of allergens.");
    }
    
    [Fact]
    public void RemoveAllergenByCrossContamination_WithNotAlreadyPresentAllergen_ThrowsException()
    {
        var sut = new AllergenClassification(
            DefaultMaterialId,
            new AllergenByNature(new List<IndividualAllergen>()),
            new AllergenByCrossContamination(new[] { _soy, _wheat }.ToList()));

        var action = () => sut.RemoveExistingAllergenByCrossContamination(_peanuts);

        action
            .Should()
            .Throw<CannotRemoveNotPresentAllergensException>()
            .WithMessage("Cannot remove not present allergen: the allergen 'Peanuts' cannot be removed, as it's not present in the current set of allergens.");
    } 
    
    [Fact]
    public void RemoveAllergenByNature_WithAlreadyPresentAllergen_RemovesAllergenFromCollection()
    {
        var sut = new AllergenClassification(
            DefaultMaterialId,
            new AllergenByNature(new[] { _soy, _wheat, _peanuts }.ToList()),
            new AllergenByCrossContamination(new[] { _soy, _wheat, _peanuts }.ToList()));
        
        sut.RemoveExistingAllergenByNature(_peanuts);

        sut.ByNatureAllergens.Allergens
            .Should()
            .BeEquivalentTo(new [] { _soy, _wheat });
        
        sut.CrossContaminatingAllergens.Allergens
            .Should()
            .BeEquivalentTo(new [] { _soy, _wheat, _peanuts });
    }
    
    [Fact]
    public void RemoveAllergenByCrossContamination_WithAlreadyPresentAllergen_RemovesAllergenFromCollection()
    {
        var sut = new AllergenClassification(
            DefaultMaterialId,
            new AllergenByNature(new[] { _soy, _wheat, _peanuts }.ToList()),
            new AllergenByCrossContamination(new[] { _soy, _wheat, _peanuts }.ToList()));
        
        sut.RemoveExistingAllergenByCrossContamination(_peanuts);

        sut.ByNatureAllergens.Allergens
            .Should()
            .BeEquivalentTo(new [] { _soy, _wheat, _peanuts });
        
        sut.CrossContaminatingAllergens.Allergens
            .Should()
            .BeEquivalentTo(new [] { _soy, _wheat });
    }    
}