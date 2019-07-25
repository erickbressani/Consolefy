using System;

namespace FluentConsoleApplication
{
    public sealed partial class FluentConsole : IFluentConsole
    {
        private ConsoleColor? _currentBackground;

        public IFluentConsole WithBackgroundColor(ConsoleColor consoleColor)
        {
            _currentBackground = consoleColor;
            return this;
        }

        public IFluentConsole ResetColor()
        {
            Console.ResetColor();
            return this;
        }
    }
}
