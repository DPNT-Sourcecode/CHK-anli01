namespace BeFaster.App.Solutions.CHK;

public static class ProductOffers
{
    public static readonly Dictionary<char, IEnumerable<Offer>> Values = new()
    {
        { 'A', new List<Offer> { new(3, 130), new(5, 200) } },
        { 'B', new List<Offer> { new(2, 45) } }
    };
}