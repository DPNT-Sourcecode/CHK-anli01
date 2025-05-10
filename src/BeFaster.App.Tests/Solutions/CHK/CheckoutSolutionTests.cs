using BeFaster.App.Solutions.CHK;
using FluentAssertions;

namespace BeFaster.App.Tests.Solutions.CHK;

[TestFixture]
public class CheckoutSolutionTests
{
    private static readonly Dictionary<char, int> _productPrices = ProductPrices.Values;
    private static readonly Dictionary<char, Offer> _productOffers = ProductOffers.Values;

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
    
    
    private static IEnumerable<(string, int)> _checkoutTestCases =
        new List<(string, int)>
        { 
            ("A", _productPrices['A']),
            ( "B", _productPrices['B'] ),
            ( "C", _productPrices['C'] ),
            ( "D", _productPrices['D'] ),
            ( "ABCD", _productPrices['A']+_productPrices['B']+_productPrices['C']+_productPrices['D'] ),
            ( "AA", _productPrices['A']*2 ),
            ( "BB", _productOffers['B'].Price ),
            ( "CC", _productPrices['C']*2 ),
            ( "DD", _productPrices['D']*2 )
        };

    [TestCaseSource(nameof(_checkoutTestCases))]
    public void Checkout_WhenInputValid_ReturnsExpected((string, int) input)
    {
        // Arrange
        var (stockKeepingUnits, expectedResult) = input;
        
        // Act
        var result = CheckoutSolution.Checkout(stockKeepingUnits);

        // Assert
        result.Should().Be(expectedResult);
    }
}
