using System;

namespace Consolefy
{
    public interface IConsolefy
    {
        IConsolefy Write(object value);

        IConsolefy WriteFormat(string value, params object[] args);

        IConsolefy Write(string value);

        IConsolefy WriteLine(object value);

        IConsolefy WriteLineFormat(string value, params object[] args);

        IConsolefy WriteLine(string value);

        IConsolefy NewEmptyLine(int repeat = 0);

        IConsolefy ReadLine(Action<string, IConsolefy> @do);

        IConsolefy ReadLineAsInt(Action<int, IConsolefy> @do, string retryText = "");

        IConsolefy ReadLineAsLong(Action<long, IConsolefy> @do, string retryText = "");

        IConsolefy ReadLineAsFloat(Action<float, IConsolefy> @do, string retryText = "");

        IConsolefy ReadLineAsDecimal(Action<decimal, IConsolefy> @do, string retryText = "");

        IConsolefy ReadLineAsGuid(Action<Guid, IConsolefy> @do, string retryText = "");

        IConsolefy ReadKey(Action<ConsoleKey, IConsolefy> @do);

        IConsolefy ReadKeyLine(Action<ConsoleKey, IConsolefy> @do);

        IConsolefy ReadLine(Action<string> @do);

        IConsolefy ReadLineAsInt(Action<int> @do, string retryText = "");

        IConsolefy ReadLineAsLong(Action<long> @do, string retryText = "");

        IConsolefy ReadLineAsFloat(Action<float> @do, string retryText = "");

        IConsolefy ReadLineAsDecimal(Action<decimal> @do, string retryText = "");

        IConsolefy ReadLineAsGuid(Action<Guid> @do, string retryText = "");

        IConsolefy ReadKey(Action<ConsoleKey> @do);

        IConsolefy ReadKeyLine(Action<ConsoleKey> @do);

        IReadTextResultWrapper ReadLineWithOptions();

        IReadTextResultWrapper ReadLineAsIntWithOptions(string retryText = "");

        IReadTextResultWrapper ReadLineAsLongWithOptions(string retryText = "");

        IReadTextResultWrapper ReadLineAsFloatWithOptions(string retryText = "");

        IReadTextResultWrapper ReadLineAsDecimalWithOptions(string retryText = "");

        IReadTextResultWrapper ReadLineAsGuidWithOptions(string retryText = "");

        IReadKeyResultWrapper ReadKeyWithOptions();

        IReadKeyResultWrapper ReadKeyLineWithOptions();

        IConsolefy WithBackgroundColor(ConsoleColor consoleColor);

        IConsolefy ResetColor();

        IConsolefy SetWindowPosition(int left, int top);

        IConsolefy SetWindowSize(int width, int height);

        IConsolefy Clear();

        IConsolefy Do(Action action);

        IConsolefy DoWithLoading(Action action, string loadingText = "Loading", int tickMilliseconds = 1000);

        IConsolefy WaitAnyKeyFromUser();

        IConsolefy SetupQuittingBehavior(Action behavior);

        IConsolefy SetupQuittingBehavior(Action<IConsolefy> behavior);

        IConsolefy Quit();
    }
}
