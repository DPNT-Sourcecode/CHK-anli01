using System.Text.RegularExpressions;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public class CheckoutSolution
    {
        
        private Dictionary<char, int> productPrices = new()
        {
            {'A', 50},
            {'B', 30},
            {'C', 20},
            {'D', 15}
        };
        
        private Dictionary<char, >
            
        public static int Checkout(string? stockKeepingUnits)
        {
            if (!IsValid(stockKeepingUnits))
            {
                return -1;
            }
            
            
            
            return 0;
        }

        private static bool IsValid(string? stockKeepingUnits)
        {
            var validRegexPattern = @"^[A-Z]+$";
            var validRegex = new Regex(validRegexPattern);

            return stockKeepingUnits != null && validRegex.IsMatch(stockKeepingUnits);
        }
    }
}
