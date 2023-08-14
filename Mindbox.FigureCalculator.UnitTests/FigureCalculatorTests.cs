namespace Mindbox.FigureCalculator.UnitTests;

public class FigureCalculatorTests
{
    #region Control methods

    private double CircleArea(double radius) => Math.PI * radius * radius;
    private double CirclePerimeter(double radius) => 2 * Math.PI * radius;

    private double TriangleArea(double sideA, double sideB, double sideC) => Math.Sqrt(
        (sideA + sideB + sideC) / 2 *
        ((sideA + sideB + sideC) / 2 - sideA) *
        ((sideA + sideB + sideC) / 2 - sideB) *
        ((sideA + sideB + sideC) / 2 - sideC));

    private double TrianglePerimeter(double sideA, double sideB, double sideC) => sideA + sideB + sideC;

    #endregion

    #region Control fields

    private readonly double _circleCommonRadius = 10;
    private readonly double _circleNegativeRadius = -1;
    private readonly double _circleDoubleRadius = 10.11;
    private readonly double _circleZeroRadius = 0;

    private readonly (double, double, double) _triangleCommonSides = (5, 3, 3);
    private readonly (double, double, double) _triangleNegativeSides = (-5, -3, -3);
    private readonly (double, double, double) _triangleDoubleSide = (5.3, 3.1, 3);
    private readonly (double, double, double) _triangleZeroSide = (0, 3, 3);
    private readonly (double, double, double) _triangleWrongSides = (1, 2, 5);

    private readonly (double, double, double) _triangleRightAngle = (5, 3, 4);

    #endregion

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
    }

    #region Circle

    #region Exceptions

    [Test]
    public void ShouldThrowExceptionWhenNegativeRadius()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Circle(_circleNegativeRadius));

        Assert.That(ex.Message, Is.EqualTo("Radius cannot be less than 0 ."));
    }

    #endregion

    #region Area calculate

    [Test]
    public void ShouldReturnCorrectAreaWhenCommonRadius()
    {
        IPlaneFigure circle = new Circle(_circleCommonRadius);

        var actualResult = circle.CalculateArea();
        var expectedResult = CircleArea(_circleCommonRadius);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ShouldReturnCorrectAreaWhenDoubleRadius()
    {
        IPlaneFigure circle = new Circle(_circleDoubleRadius);

        var actualResult = circle.CalculateArea();
        var expectedResult = CircleArea(_circleDoubleRadius);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ShouldReturnCorrectWhenCircleZeroRadius()
    {
        IPlaneFigure circle = new Circle(_circleZeroRadius);

        var actualResult = circle.CalculateArea();
        var expectedResult = 0;

        Assert.AreEqual(expectedResult, actualResult);
    }

    #endregion

    #region Perimeter calculate

    [Test]
    public void ShouldReturnCorrectPerimeterWhenCommonRadius()
    {
        IPlaneFigure circle = new Circle(_circleCommonRadius);

        var actualResult = circle.CalculatePerimeter();
        var expectedResult = CirclePerimeter(_circleCommonRadius);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ShouldReturnCorrectPerimeterWhenDoubleRadius()
    {
        IPlaneFigure circle = new Circle(_circleDoubleRadius);

        var actualResult = circle.CalculatePerimeter();
        var expectedResult = CirclePerimeter(_circleDoubleRadius);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ShouldReturnCorrectPerimeterWhenZeroRadius()
    {
        IPlaneFigure circle = new Circle(_circleZeroRadius);

        var actualResult = circle.CalculatePerimeter();
        var expectedResult = 0;

        Assert.AreEqual(expectedResult, actualResult);
    }

    #endregion

    #endregion

    #region Triangle

    #region Exceptions

    [Test]
    public void ShouldThrowArgumentExceptionWhenTriangleNegativeSides()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Triangle(
            _triangleNegativeSides.Item1,
            _triangleNegativeSides.Item2,
            _triangleNegativeSides.Item3));

        Assert.That(ex.Message, Is.EqualTo("Sides cannot be less or equal than 0 ."));
    }


    [Test]
    public void ShouldReturnCorrectAreaTriangleZeroSide()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Triangle(
            _triangleZeroSide.Item1,
            _triangleZeroSide.Item2,
            _triangleZeroSide.Item3));

        Assert.That(ex.Message, Is.EqualTo("Sides cannot be less or equal than 0 ."));
    }

    [Test]
    public void ShouldReturnCorrectAreaTriangleWrongSides()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Triangle(
            _triangleWrongSides.Item1,
            _triangleWrongSides.Item2,
            _triangleWrongSides.Item3));

        Assert.That(ex.Message, Is.EqualTo("Triangle cannot exist in Euclidean space."));
    }

    #endregion

    #region Area calculate

    [Test]
    public void ShouldReturnCorrectAreaWhenTriangleCommonSides()
    {
        IPlaneFigure triangle = new Triangle(
            _triangleCommonSides.Item1,
            _triangleCommonSides.Item2,
            _triangleCommonSides.Item3);

        var actualResult = triangle.CalculateArea();
        var expectedResult = TriangleArea(
            _triangleCommonSides.Item1,
            _triangleCommonSides.Item2,
            _triangleCommonSides.Item3);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ShouldReturnCorrectAreaTriangleDoubleSide()
    {
        IPlaneFigure triangle = new Triangle(
            _triangleDoubleSide.Item1,
            _triangleDoubleSide.Item2,
            _triangleDoubleSide.Item3);

        var actualResult = triangle.CalculateArea();
        var expectedResult = TriangleArea(
            _triangleDoubleSide.Item1,
            _triangleDoubleSide.Item2,
            _triangleDoubleSide.Item3);

        Assert.AreEqual(expectedResult, actualResult);
    }

    #endregion

    #region Perimeter calculate

    [Test]
    public void ShouldReturnCorrectPerimeterWhenTriangleCommonSides()
    {
        IPlaneFigure triangle = new Triangle(
            _triangleCommonSides.Item1,
            _triangleCommonSides.Item2,
            _triangleCommonSides.Item3);

        var actualResult = triangle.CalculatePerimeter();
        var expectedResult = TrianglePerimeter(
            _triangleCommonSides.Item1,
            _triangleCommonSides.Item2,
            _triangleCommonSides.Item3);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ShouldReturnCorrectPerimeterTriangleDoubleSide()
    {
        IPlaneFigure triangle = new Triangle(
            _triangleDoubleSide.Item1,
            _triangleDoubleSide.Item2,
            _triangleDoubleSide.Item3);

        var actualResult = triangle.CalculatePerimeter();
        var expectedResult = TrianglePerimeter(
            _triangleDoubleSide.Item1,
            _triangleDoubleSide.Item2,
            _triangleDoubleSide.Item3);

        Assert.AreEqual(expectedResult, actualResult);
    }

    #endregion

    #region Is right triangle

    [Test]
    public void ShouldReturnCorrectIsRightTriangleValueWhenRightTriangle()
    {
        Triangle triangle = new Triangle(
            _triangleRightAngle.Item1,
            _triangleRightAngle.Item2,
            _triangleRightAngle.Item3);

        var actualResult = triangle.IsRightTriangle();
        var expectedResult = true;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ShouldReturnCorrectIsRightTriangleValueWhenNotRightTriangle()
    {
        Triangle triangle = new Triangle(
            _triangleCommonSides.Item1,
            _triangleCommonSides.Item2,
            _triangleCommonSides.Item3);

        var actualResult = triangle.IsRightTriangle();
        var expectedResult = false;

        Assert.AreEqual(expectedResult, actualResult);
    }

    #endregion

    #endregion
}