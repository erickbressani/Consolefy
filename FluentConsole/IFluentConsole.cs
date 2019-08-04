using System;

namespace FluentConsoleApplication
{
    public interface IFluentConsole
    {
        IFluentConsole Write(object value);

        IFluentConsole WriteFormat(string value, params string[] args);

        IFluentConsole Write(string value);

        IFluentConsole WriteLine(object value);

        IFluentConsole WriteLineFormat(string value, params string[] args);

        IFluentConsole WriteLine(string value);

        IFluentConsole NewEmptyLine(int repeat = 0);

        IFluentConsole ReadLine(Action<string, IFluentConsole> @do);

        IFluentConsole ReadKey(Action<ConsoleKey, IFluentConsole> @do);

        IFluentConsole ReadKeyLine(Action<ConsoleKey, IFluentConsole> @do);

        IReadTextResultWrapper ReadLineWithOptions();

        IReadKeyResultWrapper ReadKeyWithOptions();

        IReadKeyResultWrapper ReadKeyLineWithOptions();

        IFluentConsole WithBackgroundColor(ConsoleColor consoleColor);

        IFluentConsole ResetColor();

        IFluentConsole SetWindowPosition(int left, int top);

        IFluentConsole SetWindowSize(int width, int height);

        IFluentConsole Clear();

        IFluentConsole Beep();

        IFluentConsole Beep(int frequency, int duration);

        IFluentConsole Do(Action action);

        IFluentConsole DoWithLoading(Action action, string loadingText = "Loading", int tickMilliseconds = 1000);
    }
}
