using FluentAssertions;
using Xunit;
using MAM.Inventory.Domain.Exceptions;
using MAM.Inventory.Domain;

namespace MAM.Inventory.UnitTests;

public class StockTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateUnitOfMeasure_WithIllegalCode_ThrowsException(string unitOfMeasureCode)
    {
        var action = () => UnitOfMeasure.Create(unitOfMeasureCode, "kilogram");

        action
            .Should()
            .Throw<InvalidUnitOfMeasureException>()
            .WithMessage("Unit of measure code is mandatory.");
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateUnitOfMeasure_WithIllegalName_ThrowsException(string unitOfMeasureName)
    {
        var action = () => UnitOfMeasure.Create("kg", unitOfMeasureName);

        action
            .Should()
            .Throw<InvalidUnitOfMeasureException>()
            .WithMessage("Unit of measure name is mandatory.");
    }

    [Theory]
    [InlineData("kg", "Kilogram")]
    [InlineData(" l ", " Liter ")]
    public void CreateUnitOfMeasure_WithLegalValues_CreatesUnitOfMeasureAndTrimsValues(string unitOfMeasureCode, string unitOfMeasureName)
    {
        var result = UnitOfMeasure.Create(unitOfMeasureCode, unitOfMeasureName);
        result.Code.Should().Be(unitOfMeasureCode.Trim());
        result.Name.Should().Be(unitOfMeasureName.Trim());
    }

    [Fact]
    public void CreateStock_WithNegativeValue_ThrowsException()
    {
        var unitOfMeasure = UnitOfMeasure.Create("kg", "Kilogram");

        var action = () => Stock.CreateInitialStock("Material1", unitOfMeasure, -1);

        action
            .Should()
            .Throw<InvalidInitialStockException>()
            .WithMessage("Initial stock must be greater than or equal to 0.");        
    }
}