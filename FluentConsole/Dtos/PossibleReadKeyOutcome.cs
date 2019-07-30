using System;

namespace FluentConsoleApplication
{
    internal class PossibleReadKeyOutcome
    {
        internal ConsoleKey ExpectedConsoleKey { get; }
        internal Action<ConsoleKey, IFluentConsole> Do { get; }

        internal PossibleReadKeyOutcome(ConsoleKey expectedConsoleKey, Action<ConsoleKey, IFluentConsole> @do)
        {
            ExpectedConsoleKey = expectedConsoleKey;
            Do = @do;
        }
    }
}
