using System;

namespace Consolefy
{
    internal class PossibleReadTextOutcome
    {
        internal string ExpectedResult { get; }
        internal Action<string, IConsolefy> Do { get; }
        internal StringComparison StringComparison { get; }

        internal PossibleReadTextOutcome(string expectedResult, Action<string, IConsolefy> @do, StringComparison stringComparison)
        {
            ExpectedResult = expectedResult;
            Do = @do;
            StringComparison = stringComparison;
        }
    }
}
