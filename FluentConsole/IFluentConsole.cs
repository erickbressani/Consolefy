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

        IReadTextResultWrapper ReadLine();

        IReadKeyResultWrapper ReadKey();

        IFluentConsole WithBackgroundColor(ConsoleColor consoleColor);

        IFluentConsole ResetColor();

        IFluentConsole SetWindowPosition(int left, int top);

        IFluentConsole SetWindowSize(int width, int height);

        IFluentConsole Clear();

        IFluentConsole Beep();

        IFluentConsole Beep(int frequency, int duration);

        IFluentConsole DoWithLoading(Action action);

        IFluentConsole DoWithLoading(Action action, string loadingText = "Loading", int tickMilliseconds = 1000);
    }
}
