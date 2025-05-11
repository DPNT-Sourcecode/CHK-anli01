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
            ( "F", _productPrices['F'] ),
            ("G", _productPrices['G']),
            ( "H", _productPrices['H'] ),
            ( "I", _productPrices['I'] ),
            ( "J", _productPrices['J'] ),
            ( "K", _productPrices['K'] ),
            ( "L", _productPrices['L'] ),
            ("M", _productPrices['M']),
            ( "N", _productPrices['N'] ),
            ( "O", _productPrices['O'] ),
            ( "P", _productPrices['P'] ),
            ( "Q", _productPrices['Q'] ),
            ( "R", _productPrices['R'] ),
            ( "S", _productPrices['S'] ),
            ( "T", _productPrices['T'] ),
            ( "U", _productPrices['U'] ),
            ( "V", _productPrices['V'] ),
            ( "W", _productPrices['W'] ),
            ( "X", _productPrices['X'] ),
            ( "Y", _productPrices['Y'] ),
            ( "Z", _productPrices['Z'] ),
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
    [TestCase("HHHHHHHHH", 85)]
    [TestCase("VVVVV", 220)]
    [TestCase("VVVVVVV", 310)]
    public void Checkout_WhenMultipleDiscountOffers_ReturnsExpected(string stockKeepingUnits, int expectedResult)
    {
        // Act
        var result = CheckoutSolution.Checkout(stockKeepingUnits);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [TestCase("EEEEBB", 160)]
    [TestCase("FFF", 20)]
    [TestCase("FFFFFF", 40)]
    [TestCase("FFFEEEEBB", 180)]
    [TestCase("BBEE", 110)]
    [TestCase("FF", 20)]
    [TestCase("ANNNNMAAA", 340)]
    [TestCase("RRRQ", 150)]
    [TestCase("UUUUU", 160)]
    public void Checkout_WhenFreeOffers_ReturnsExpected(string stockKeepingUnits, int expectedResult)
    {
        // Act
        var result = CheckoutSolution.Checkout(stockKeepingUnits);

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [TestCase("SSS", 45)]
    [TestCase("STX", 45)]
    [TestCase("STXX", 62)]
    [TestCase("STXXXX", 90)]
    [TestCase("STXTXYXYZ", 135)]
    [TestCase("STXTXYXYK", 197)]
    public void Checkout_WhenGroupDiscountOffers_ReturnsExpected(string stockKeepingUnits, int expectedResult)
    {
        // Act
        var result = CheckoutSolution.Checkout(stockKeepingUnits);

        // Assert
        result.Should().Be(expectedResult);
    }
}


