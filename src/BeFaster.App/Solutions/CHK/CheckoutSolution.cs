using System.Text.RegularExpressions;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public class CheckoutSolution
    {
        public static int Checkout(string? stockKeepingUnits)
        {
            if (!IsValid(stockKeepingUnits))
            {
                return -1;
            }
            var totalPrice = 0;
            var checkoutItems = new Dictionary<char, int>();

            foreach (var product in stockKeepingUnits!)
            {
                if (!checkoutItems.TryAdd(product, 1))
                {
                    checkoutItems[product]++;
                }
            }
            
            foreach (var item in checkoutItems)
            {
                var product = item.Key;
                var quantity = item.Value;

                if (ProductPrices.Values.TryGetValue(product, out var price))
                {
                    totalPrice += price * quantity;
                }

                if (ProductOffers.Values.TryGetValue(product, out var offer))
                {
                    var offerQuantity = offer.Quantity;
                    var offerPrice = offer.Price;

                    if (quantity >= offerQuantity)
                    {
                        var numberOfOffers = quantity / offerQuantity;
                        totalPrice -= (ProductPrices.Values[product] * offerQuantity - offerPrice) * numberOfOffers;
                    }
                }
            }

            return totalPrice;
        }

        private static bool IsValid(string? stockKeepingUnits)
        {
            var validRegexPattern = @"^[A-Z]*$";
            var validRegex = new Regex(validRegexPattern);

            return stockKeepingUnits != null && validRegex.IsMatch(stockKeepingUnits);
        }
    }
}

