using Excel.Parsing;

namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestTrueSubtractTrue()
    {
        // Setup
        var expression = "True - True";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestTrueSubtractFalse()
    {
        // Setup
        var expression = "True - False";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseSubtractTrue()
    {
        // Setup
        var expression = "False - True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseSubtractFalse()
    {
        // Setup
        var expression = "False - False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
