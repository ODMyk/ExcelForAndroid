namespace CalculatorTests;

public partial class CalculatorUnitTests
{
    [TestMethod]
    public void TestTrueAddTrue()
    {
        // Setup
        var expression = "True + True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestTrueAddFalse()
    {
        // Setup
        var expression = "True + False";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseAddTrue()
    {
        // Setup
        var expression = "False + True";
        var expected = true;

        // Act and Assert
        AssertExpression(expression, expected);
    }

    [TestMethod]
    public void TestFalseAddFalse()
    {
        // Setup
        var expression = "False + False";
        var expected = false;

        // Act and Assert
        AssertExpression(expression, expected);
    }
}
