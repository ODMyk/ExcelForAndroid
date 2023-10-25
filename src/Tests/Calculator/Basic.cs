using Excel.Parsing;

namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    private static void AssertExpression(string expression, bool expectedValue)
    {
        // Act
        var actualValue = Calculator.Evaluate(expression);

        // Assert
        Assert.AreEqual(expectedValue, actualValue);
    }
}
