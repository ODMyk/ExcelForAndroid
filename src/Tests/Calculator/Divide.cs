using Excel.Parsing;

namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestTrueDivideTrue()
    {
        // Setup
        var expression = "True / True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestTrueDivideFalse()
    {
        // Setup
        var expression = "True / False";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseDivideTrue()
    {
        // Setup
        var expression = "False / True";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseDivideFalse()
    {
        // Setup
        var expression = "False / False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
