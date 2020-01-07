using System;

namespace Consolefy
{
    public interface IReadKeyResultWrapper
    {
        IReadKeyResultWrapper If(ConsoleKey result, Action<ConsoleKey, IConsolefy> @do);

        IReadKeyResultWrapper If(ConsoleKey result, Action<ConsoleKey> @do);

        IReadKeyResultWrapper If(ConsoleKey result, Action @do);

        IConsolefy Else(Action<ConsoleKey, IConsolefy> @do);

        IConsolefy Else(Action<ConsoleKey> @do);

        IConsolefy Else(Action @do);

        IConsolefy ElseRetry(string retryText = "");
    }
}
