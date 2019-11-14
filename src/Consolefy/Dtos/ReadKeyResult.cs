using System;

namespace Consolefy
{
    internal class ReadKeyResult
    {
        internal ConsoleKey ConsoleKey { get; }

        internal ReadKeyResult(ConsoleKey consoleKey)
            => ConsoleKey = consoleKey;
    }
}
