using ShapeCalculator.Area;
using Xunit;

namespace ShapeCalculator.Tests;

public class TriangleAreaTests
{
    private Triangle _triangle { get; set; }

    [Theory]
    [InlineData(2, 3, 4, 2.904)]
    [InlineData(12.3, 11.5, 17.1, 70.69)]
    public void TestCalculateArea_ReturnsCorrectResult(double a,
        double b, double c, double expectedValue)
    {
        _triangle = new Triangle(a, b, c);
        Assert.Equal(expectedValue, _triangle.CalculateArea(), 2);
    }
    
    [Theory]
    [InlineData(3, 4, 5)]
    public void IsRightTriangle_ReturnsTrue_WhenTriangleIsRightAngled(
        double a, double b, double c)
    {
        _triangle = new Triangle(a, b, c);
        Assert.True(_triangle.IsRightTriangle());
    }
    
    [Theory]
    [InlineData(2.1, 3, 6)]
    [InlineData(12.1, 2.05, 9)]
    public void IsValidTriangle_ThrowsArgumentException_WhenTriangleIsInvalid(
        double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(
            () => _triangle = new Triangle(a, b, c));
    }
}