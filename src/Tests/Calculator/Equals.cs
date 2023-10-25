using Excel.Parsing;

namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestTrueEqualsTrue()
    {
        // Setup
        var expression = "True == True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestTrueEqualsFalse()
    {
        // Setup
        var expression = "True == False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseEqualsTrue()
    {
        // Setup
        var expression = "False == True";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseEqualsFalse()
    {
        // Setup
        var expression = "False == False";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
