namespace BeFaster.App.Solutions.CHK;

public static class ProductOffers
{
    public static readonly Dictionary<char, IEnumerable<DiscountOffer>> DiscountOffers = new()
    {
        { 'A', new List<DiscountOffer> { new(3, 130), new(5, 200) } },
        { 'B', new List<DiscountOffer> { new(2, 45) } }
    };
    
    
}