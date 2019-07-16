using System;

namespace FluentConsoleApplication
{
    internal class ReadKeyResult
    {
        public ConsoleKey ConsoleKey { get; }

        internal ReadKeyResult(ConsoleKey consoleKey)
        {
            ConsoleKey = consoleKey;
        }
    }
}
