using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.HLO
{
    public class HelloSolution
    {
        public string Hello(string? friendName)
        {
            return string.IsNullOrEmpty(friendName) ? "Hello" : $"Hello {friendName}";
        }
    }
}

