using System;

namespace Consolefy
{
    internal class PossibleReadKeyOutcome
    {
        internal ConsoleKey ExpectedConsoleKey { get; }
        internal Action<ConsoleKey, IConsolefy> Do { get; }

        internal PossibleReadKeyOutcome(ConsoleKey expectedConsoleKey, Action<ConsoleKey, IConsolefy> @do)
        {
            ExpectedConsoleKey = expectedConsoleKey;
            Do = @do;
        }
    }
}
