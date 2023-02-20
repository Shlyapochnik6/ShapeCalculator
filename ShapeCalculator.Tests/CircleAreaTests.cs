using ShapeCalculator.Area;
using Xunit;

namespace ShapeCalculator.Tests;

public class CircleAreaTests
{
    private Circle _circle { get; set; }

    [Theory]
    [InlineData(3, 28.274)]
    [InlineData(4.4, 60.82)]
    public void TestCalculateArea_ReturnsCorrectResult(double a,
        double expectedValue)
    {
        _circle = new Circle(a);
        Assert.Equal(expectedValue, _circle.CalculateArea(), 2);
    }
}