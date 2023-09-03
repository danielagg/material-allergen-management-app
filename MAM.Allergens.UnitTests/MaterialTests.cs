using FluentAssertions;

namespace MAM.Allergens.UnitTests;

public class MaterialTests
{
    [Fact]
    public void Test1()
    {
        var sut = 1;
        sut.Should().Be(1);
    }
}