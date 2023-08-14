using Mindbox.FigureCalculator.Interfaces;

namespace Mindbox.FigureCalculator.Figures;

public record Triangle : IPlaneFigure
{
    private const double Tolerance = 0.001;

    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    /// <summary>
    /// Creates an instance of a triangle.
    /// </summary>
    /// <param name="sideA">First side</param>
    /// <param name="sideB">Second side</param>
    /// <param name="sideC">Third side</param>
    /// <exception cref="ArgumentException">When one or few sides are less than 0.</exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Sides cannot be less or equal than 0 .");
        }

        if (sideA + sideB < sideC ||
            sideA + sideC < sideB ||
            sideB + sideC < sideA)
        {
            throw new ArgumentException("Triangle cannot exist in Euclidean space.");
        }

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public double CalculateArea()
    {
        double halfPerimeter = CalculatePerimeter() / 2;

        return Math.Sqrt(
            halfPerimeter *
            (halfPerimeter - _sideA) *
            (halfPerimeter - _sideB) *
            (halfPerimeter - _sideC));
    }

    public double CalculatePerimeter() => _sideA + _sideB + _sideC;


    /// <returns>The value whether the triangle is right</returns>
    public bool IsRightTriangle() =>
        Math.Abs(Math.Pow(_sideA, 2) + Math.Pow(_sideB, 2) - Math.Pow(_sideC, 2)) < Tolerance ||
        Math.Abs(Math.Pow(_sideA, 2) + Math.Pow(_sideC, 2) - Math.Pow(_sideB, 2)) < Tolerance ||
        Math.Abs(Math.Pow(_sideB, 2) + Math.Pow(_sideC, 2) - Math.Pow(_sideA, 2)) < Tolerance;
}