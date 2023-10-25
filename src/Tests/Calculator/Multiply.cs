using Excel.Parsing;

namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestTrueMultiplyTrue()
    {
        // Setup
        var expression = "True * True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestTrueMultiplyFalse()
    {
        // Setup
        var expression = "True * False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseMultiplyTrue()
    {
        // Setup
        var expression = "False * True";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseMultiplyFalse()
    {
        // Setup
        var expression = "False * False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
