using System;

namespace FluentConsoleApplication
{
    internal class PossibleReadTextOutcome
    {
        internal string ExpectedResult { get; }
        internal Action<string, IFluentConsole> Do { get; }
        internal StringComparison StringComparison { get; }

        internal PossibleReadTextOutcome(string expectedResult, Action<string, IFluentConsole> @do, StringComparison stringComparison)
        {
            ExpectedResult = expectedResult;
            Do = @do;
            StringComparison = stringComparison;
        }
    }
}
