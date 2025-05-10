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
            Regex r = new Regex(validRegexPattern);
            if (string.IsNullOrEmpty(stockKeepingUnits) || string.IsNullOrWhiteSpace(stockKeepingUnits))
            {
                return false;
            }
            
            foreach (var c in stockKeepingUnits)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}



