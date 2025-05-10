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
    
    
    public static IEnumerable<(string, int)> CheckoutTestCases
    {
        get
        {
            return new()
            { 
                ("A", _productPrices['A']),
                // { "B", _productPrices['B'] },
                // { "C", _productPrices['C'] },
                // { "D", _productPrices['D'] },
                // { "ABCD", _productPrices['A']+_productPrices['B']+_productPrices['C']+_productPrices['D'] },
                // { "AA", _productPrices['A']*2 },
                // { "BB", _productPrices['B']*2 },
                // { "CC", _productPrices['C']*2 },
                // { "DD", _productPrices['D']*2 }
            };
        }
    }

    [TestCaseSource(nameof(CheckoutTestCases))]
    public void Checkout_WhenInputValid_ReturnsExpected(string? validInput, int expectedResult)
    {
        // Act
        var result = CheckoutSolution.Checkout(validInput);

        // Assert
        result.Should().Be(expectedResult);
    }
}

