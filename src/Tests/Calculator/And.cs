namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestTrueAndTrue()
    {
        // Setup
        var expression = "True && True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestTrueAndFalse()
    {
        // Setup
        var expression = "True && False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseAndTrue()
    {
        // Setup
        var expression = "False && True";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseAndFalse()
    {
        // Setup
        var expression = "False && False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
