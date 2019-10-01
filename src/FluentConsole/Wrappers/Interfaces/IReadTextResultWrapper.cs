using System;

namespace FluentConsoleApplication
{
    public interface IReadTextResultWrapper
    {
        IReadTextResultWrapper If(string result, Action<string, IFluentConsole> @do, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase);

        IFluentConsole Else(Action<string, IFluentConsole> @do);

        IFluentConsole ElseRetry(string retryText = "");
    }
}
