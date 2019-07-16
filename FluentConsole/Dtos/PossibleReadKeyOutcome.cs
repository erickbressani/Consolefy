using System;

namespace FluentConsoleApplication
{
    internal class PossibleReadKeyOutcome
    {
        internal ConsoleKey ExpectedConsoleKey { get; }
        internal Action<ConsoleKey, IFluentConsole> Do { get; }

        public PossibleReadKeyOutcome(ConsoleKey expectedConsoleKey, Action<ConsoleKey, IFluentConsole> @do)
        {
            ExpectedConsoleKey = expectedConsoleKey;
            Do = @do;
        }
    }
}
