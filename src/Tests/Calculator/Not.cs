using Excel.Parsing;

namespace CalculatorTests;

[TestClass]
public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestNotTrue()
    {
        // Setup
        var expression = "!True";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestNotFalse()
    {
        // Setup
        var expression = "!False";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
