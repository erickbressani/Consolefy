using System;

namespace Consolefy
{
    public interface IReadTextResultWrapper
    {
        IReadTextResultWrapper If(string result, Action<string, IConsolefy> @do, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase);

        IConsolefy Else(Action<string, IConsolefy> @do);

        IConsolefy ElseRetry(string retryText = "");
    }
}
