namespace Mindbox.FigureCalculator.Interfaces;

/// <summary>
/// Represents the 2D figures
/// </summary>
public interface IPlaneFigure
{
    /// <returns>The area of the figure</returns>
    double CalculateArea();

    /// <returns>The length of the sides of the figure</returns>
    double CalculatePerimeter();
}