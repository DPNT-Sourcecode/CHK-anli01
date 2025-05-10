using System.Text.RegularExpressions;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public class CheckoutSolution
    {
        public int Checkout(string? stockKeepingUnits)
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




