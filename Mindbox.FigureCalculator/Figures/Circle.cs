using Mindbox.FigureCalculator.Interfaces;

namespace Mindbox.FigureCalculator.Figures;

public record Circle : IPlaneFigure
{
    private readonly double _radius;

    /// <summary>
    /// Creates an instance of a circle.
    /// </summary>
    /// <param name="radius">Circle's radius</param>
    /// <exception cref="ArgumentException">When radius is less than 0.</exception>
    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Radius cannot be less than 0 .");
        }

        _radius = radius;
    }

    public double CalculateArea() => Math.PI * _radius * _radius;

    public double CalculatePerimeter() => 2 * Math.PI * _radius;
}