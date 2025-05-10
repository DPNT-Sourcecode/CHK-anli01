using BeFaster.App.Solutions.CHK;
using FluentAssertions;

namespace BeFaster.App.Tests.Solutions.CHK;

[TestFixture]
public class CheckoutSolutionTests
{
    private static Dictionary<char, int> _productPrices = null!;
    private Dictionary<char, Offer> productOffers = null!;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _productPrices = ProductPrices.Values;
        productOffers = ProductOffers.Values;
    }


    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("5")]
    [TestCase("a")]
    [TestCase("1a")]
    [TestCase("*")]
    [TestCase("A_B")]
    public void Checkout_WhenInputInvalid_ReturnsMinusOne(string? invalidInput)
    {
        // Act
        var result = CheckoutSolution.Checkout(invalidInput);

        // Assert
        result.Should().Be(-1);
    }
    
    
    public static IEnumerable<object[]> AdditionData
    {
        get
        {
            return new[]
            { 
                new object[] { 1, 1, 2 },
                new object[] { 2, 2, 4 },
                new object[] { 3, 3, 6 },
                new object[] { 0, 0, 1 }, // The test run with this row fails
            };
        }
    }
    
    [TestCase("A", _productPrices['A'])]
    public void Checkout_WhenInputValid_ReturnsExpected(string? invalidInput, int expectedResult)
    {
        // Arrange
        var validInput = "ABCD";
        var expectedPrice = 50 + 30 + 20 + 15;

        // Act
        var result = CheckoutSolution.Checkout(validInput);

        // Assert
        result.Should().Be(expectedPrice);
    }
}
