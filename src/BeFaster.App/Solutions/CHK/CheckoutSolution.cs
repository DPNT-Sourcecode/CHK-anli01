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
                totalPrice += ProductPrices.Values.GetValueOrDefault(product, 0);
            }
            quantityToApplyOffers = checkoutItems
            foreach (var item in checkoutItems)
            {
                var product = item.Key;
                var quantityPurchased = item.Value;
                var quantityToApplyOffers = quantityPurchased;
                
                totalPrice -= GetDiscountPrice(product, quantityToApplyOffers, checkoutItems);
            }

            return totalPrice;
        }

        private static int GetDiscountPrice(char product, int quantityToApplyDiscountOffers, Dictionary<char, int> checkoutItems)
        {
            
            var totalDiscountPrice = 0;
            var freeOffers = GetFreeOffersForProduct(product);
            foreach (var freeOffer in freeOffers!)
            {
                var offerQuantity = freeOffer.Quantity;
                var offerProduct = freeOffer.Product;
                    
                var numberOfFreeOffers = checkoutItems[product] / offerQuantity;
                var offersToApply = Math.Min(checkoutItems[product], numberOfFreeOffers);
                totalDiscountPrice += ProductPrices.Values[product] * offersToApply;
                quantityToApplyDiscountOffers -= offersToApply;
            }

            if (ProductOffers.DiscountOffers.TryGetValue(product, out var discountOffers))
            {
                discountOffers = discountOffers.OrderByDescending(x => x.Quantity);
                foreach (var offer in discountOffers)
                {
                    var discountOfferPrice = GetDiscountOfferPrice(product, quantityToApplyDiscountOffers, offer, out var offerApplied);
                    if (discountOfferPrice > 0)
                    {
                        totalDiscountPrice += discountOfferPrice;
                        quantityToApplyDiscountOffers -= offerApplied * offer.Quantity;
                    }
                }
            }

            return totalDiscountPrice;
        }

        private static IEnumerable<FreeOffer> GetFreeOffersForProduct(char product)
        {
            return ProductOffers.FreeOffers.Values.Where(x => x.Product == product).OrderByDescending(x => x.Quantity);
        }

        private static int GetDiscountOfferPrice(char product, int quantityPurchased, DiscountOffer discountOffer, out int offerApplied)
        {
            var offerQuantity = discountOffer.Quantity;
            var offerPrice = discountOffer.Price;

            if (quantityPurchased < offerQuantity)
            {
                offerApplied = 0;
                return 0;
            }
            
            var numberOfOffers = quantityPurchased / offerQuantity;
            offerApplied = numberOfOffers;
            return (ProductPrices.Values[product] * offerQuantity - offerPrice) * numberOfOffers;

        }

        private static bool IsValid(string? stockKeepingUnits)
        {
            var validRegexPattern = @"^[A-Z]*$";
            var validRegex = new Regex(validRegexPattern);

            return stockKeepingUnits != null && validRegex.IsMatch(stockKeepingUnits);
        }
    }
}
