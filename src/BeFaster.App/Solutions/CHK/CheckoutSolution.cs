using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public class CheckoutSolution
    {
        public int Checkout(string? skus)
        {
            if (!IsValid(skus))
            {
                return -1;
            }

            return 0;
        }

        private static bool IsValid(string? skus)
        {
            if (string.IsNullOrEmpty(skus))
            {
                return false;
            }

            foreach (var c in skus)
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


