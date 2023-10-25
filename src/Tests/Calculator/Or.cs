using Excel.Parsing;

namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestTrueOrTrue()
    {
        // Setup
        var expression = "True || True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestTrueOrFalse()
    {
        // Setup
        var expression = "True || False";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseOrTrue()
    {
        // Setup
        var expression = "False || True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseOrFalse()
    {
        // Setup
        var expression = "False || False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
