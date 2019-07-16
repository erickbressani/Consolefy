using System;

namespace FluentConsoleApplication
{
    public interface IReadKeyResultWrapper
    {
        IReadKeyResultWrapper If(ConsoleKey result, Action<ConsoleKey, IFluentConsole> @do);

        IFluentConsole Else(Action<ConsoleKey, IFluentConsole> @do);

        IFluentConsole ElseRetry(string retryText = "");
    }
}
