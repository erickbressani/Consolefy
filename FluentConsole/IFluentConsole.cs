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

        IFluentConsole Clear();

        IReadTextResultWrapper ReadLine();

        IReadKeyResultWrapper ReadKey();

        IFluentConsole WithBackgroundColor(ConsoleColor consoleColor);

        IFluentConsole ResetColor();
    }
}
