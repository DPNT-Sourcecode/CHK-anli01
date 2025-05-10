using BeFaster.App.Solutions.CHK;
using FluentAssertions;

namespace BeFaster.App.Tests.Solutions.CHK;

[TestFixture]
public class CheckoutSolutionTests
{
    private static readonly Dictionary<char, int> _productPrices = ProductPrices.Values;
    private static readonly Dictionary<char, IEnumerable<DiscountOffer>> _productDiscountOffers = ProductOffers.DiscountOffers;

    [TestCase(null)]
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
            ("", 0),
            ("A", _productPrices['A']),
            ( "B", _productPrices['B'] ),
            ( "C", _productPrices['C'] ),
            ( "D", _productPrices['D'] ),
            ( "E", _productPrices['E'] ),
            ( "ABCD", _productPrices['A']+_productPrices['B']+_productPrices['C']+_productPrices['D'] ),
            ( "AA", _productPrices['A']*2 ),
            ( "BB", _productDiscountOffers['B'].First().Price ),
            ( "CC", _productPrices['C']*2 ),
            ( "DD", _productPrices['D']*2 ),
            ( "EE", _productPrices['E']*2 ),
            ( "AAA", _productDiscountOffers['A'].First().Price )
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
    
    [TestCase("AAAAAAAAAAAAAAA", 600)]
    [TestCase("AAAAAAAA", 330)]
    [TestCase("AAAAAAAAA", 380)]
    public void Checkout_WhenMultipleDiscountOffers_ReturnsExpected(string stockKeepingUnits, int expectedResult)
    {
        // Act
        var result = CheckoutSolution.Checkout(stockKeepingUnits);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void Checkout_WhenFreeOffers_ReturnsExpected()
    {
        // Arrange
        var stockKeepingUnits = "BBEE";
        var expectedResult = _productDiscountOffers['B'].First().Price + _productPrices['E'] * 2 - _productPrices['B'];
        
        // Act
        var result = CheckoutSolution.Checkout(stockKeepingUnits);

        // Assert
        result.Should().Be(expectedResult);
    }
}
