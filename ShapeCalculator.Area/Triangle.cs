using ShapeCalculator.Area.Interfaces;

namespace ShapeCalculator.Area;

public class Triangle : Shape, ITriangle
{
    private const double _precision = 1e-10;
    
    public double FirstSide { get; set; }
    public double SecondSide { get; set; }
    public double ThirdSide { get; set; }

    public Triangle(double firstSide, double secondSide,
        double thirdSide)
    {
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
        IsValidTriangle();
    }
    
    public override double CalculateArea()
    {
        var p = (FirstSide + SecondSide + ThirdSide) / 2;
        return Math.Sqrt(p * (p - FirstSide) * 
                             (p - SecondSide) * (p - ThirdSide));
    }

    public bool IsRightTriangle()
    {
        var sides = new List<double>() { FirstSide, SecondSide, ThirdSide };
        var biggestSide = sides.Max();
        var twoSidesSum = sides.Where(s => s < biggestSide)
            .Sum(s => Math.Pow(s, 2));
        return Math.Abs(twoSidesSum - Math.Pow(biggestSide, 2)) < _precision;
    }
    
    public void IsValidTriangle()
    {
        if (FirstSide + SecondSide <= ThirdSide ||
            FirstSide + ThirdSide <= SecondSide ||
            SecondSide + ThirdSide <= FirstSide)
            throw new ArgumentException($"Incorrect values of the sides");
    }
}