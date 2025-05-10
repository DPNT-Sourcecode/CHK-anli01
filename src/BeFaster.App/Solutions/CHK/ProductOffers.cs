namespace BeFaster.App.Solutions.CHK;

public static class ProductOffers
{
    public static readonly Dictionary<char, Offer> Values = new()
    {
        {'A', new Offer(3, 130)},
        {'B', new Offer(2, 45)}
    };
}