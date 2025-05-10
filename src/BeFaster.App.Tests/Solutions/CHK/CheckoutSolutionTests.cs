using BeFaster.App.Solutions.CHK;
using FluentAssertions;

namespace BeFaster.App.Tests.Solutions.CHK;

[TestFixture]
public class CheckoutSolutionTests
{
    [Test]
    public void Checkout_WhenInputInvalid_ReturnsMinusOne()
    {
        // Arrange
        var checkoutSolution = new CheckoutSolution();
        string? invalidInput = null;

        // Act
        var result = checkoutSolution.Checkout(invalidInput);

        // Assert
        result.Should().Be(-1);
    }
}

