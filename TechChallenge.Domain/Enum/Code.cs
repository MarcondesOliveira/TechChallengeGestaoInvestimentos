namespace TechChallengeGestaoInvestimentos.Domain.Enum
{
    public enum Code
    {
        AAPL = 1,
        BTC = 2
    }

    public static class CodeExtensions
    {
        private static readonly Dictionary<Code, string> CodeNames = new Dictionary<Code, string>
        {
            { Code.AAPL, "Apple" },
            { Code.BTC, "Bitcoin" }
        };

        public static string GetName(this Code code)
        {
            return CodeNames.TryGetValue(code, out var name) ? name : "Unknown";
        }
    }
}
