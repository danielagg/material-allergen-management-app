namespace MAM.Materials.UnitTests;

public class MaterialCodeTests
{
    [Theory]
    [InlineData(null, "Material code cannot be empty")]
    [InlineData("", "Material code cannot be empty")]
    [InlineData("12345", "Material code must be 6 characters long")]
    [InlineData("1234567", "Material code must be 6 characters long")]
    [InlineData("T23456", "Material code must start with P or R")]
    public void CreateMaterialCode_WithIllegalFormattedMaterialId_ThrowsException(string materialCode, string expectedExceptionMessage)
    {
        var action = () => MaterialCode.Create(materialCode);

        action
            .Should()
            .Throw<InvalidMaterialCodeException>()
            .WithMessage(expectedExceptionMessage);
    }

    [Theory]
    [InlineData("R12345")]
    [InlineData("P12345")]
    [InlineData(" P12345 ")]
    public void CreateMaterialCode_WithLegalValue_CreatesAndTrimsMaterialCode(string materialCode)
    {
        var result = MaterialCode.Create(materialCode);
        result.Value.Should().Be(materialCode.Trim());
    }
}