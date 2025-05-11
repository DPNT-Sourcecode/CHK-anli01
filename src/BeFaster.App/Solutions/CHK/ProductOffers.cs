namespace BeFaster.App.Solutions.CHK;

public static class ProductOffers
{
    public static readonly Dictionary<char, IEnumerable<DiscountOffer>> DiscountOffers = new()
    {
        { 'A', new List<DiscountOffer> { new(3, 130), new(5, 200) } },
        { 'B', new List<DiscountOffer> { new(2, 45) } },
        { 'H', new List<DiscountOffer> { new(5, 45), new(10, 80) } },
        { 'K', new List<DiscountOffer> { new(2, 120) } },
        { 'P', new List<DiscountOffer> { new(5, 200) } },
        { 'Q', new List<DiscountOffer> { new(3, 80) } },
        { 'V', new List<DiscountOffer> { new(2, 90), new(3, 130) } },
    };
    
    public static readonly Dictionary<char, FreeOffer> FreeOffers = new()
    {
        { 'B', new(2, 'E') },
        { 'F', new(2, 'F') },
        { 'M', new(3, 'N') },
        { 'Q', new(3, 'R') },
        { 'U', new(3, 'U') },
    };
    
    public static readonly Dictionary<char, GroupDiscountOffer> GroupDiscountOffers = new()
    {
        { 'S', new(3, 45, ['S', 'T', 'X', 'Y', 'Z']) },
        { 'T', new(3, 45, ['S', 'T', 'X', 'Y', 'Z']) },
        { 'X', new(3, 45, ['S', 'T', 'X', 'Y', 'Z']) },
        { 'Y', new(3, 45, ['S', 'T', 'X', 'Y', 'Z']) },
        { 'Z', new(3, 45, ['S', 'T', 'X', 'Y', 'Z']) },
    };
    
}
