using Excel.Parsing;

namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestTrueNotEqualsTrue()
    {
        // Setup
        var expression = "True <> True";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestTrueNotEqualsFalse()
    {
        // Setup
        var expression = "True <> False";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseNotEqualsTrue()
    {
        // Setup
        var expression = "False <> True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseNotEqualsFalse()
    {
        // Setup
        var expression = "False <> False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
