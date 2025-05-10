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
            
            foreach (var item in checkoutItems)
            {
                var product = item.Key;
                var quantityPurchased = item.Value;
                var quantityToApplyOffers = quantityPurchased;
                
                totalPrice -= GetDiscountPrice(product, quantityToApplyOffers, checkoutItems);
            }

            return totalPrice;
        }

        private static int GetDiscountPrice(char product, int quantityToApplyOffers, Dictionary<char, int> checkoutItems)
        {
            
            var totalDiscountPrice = 0;
            
            if(ProductOffers.FreeOffers.TryGetValue(product, out var freeOffer))
            {
                var offerQuantity = freeOffer.Quantity;
                var offerProduct = freeOffer.Product;
                    
                var numberOfFreeOffers = quantityToApplyOffers / offerQuantity;
                var offersToApply = checkoutItems.ContainsKey(offerProduct)
                    ? Math.Min(numberOfFreeOffers, quantityToApplyOffers)
                    : 0;
                totalDiscountPrice += ProductPrices.Values[offerProduct] * offersToApply;
                quantityToApplyOffers -= offersToApply * offerQuantity;
            }

            if (ProductOffers.DiscountOffers.TryGetValue(product, out var discountOffers))
            {
                discountOffers = discountOffers.OrderByDescending(x => x.Quantity);
                foreach (var offer in discountOffers)
                {
                    var discountOfferPrice = GetDiscountOfferPrice(product, quantityToApplyOffers, offer, out var offerApplied);
                    if (discountOfferPrice > 0)
                    {
                        totalDiscountPrice += discountOfferPrice;
                        quantityToApplyOffers -= offerApplied * offer.Quantity;
                    }
                }
            }

            return totalDiscountPrice;
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

