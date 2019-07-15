using System;

namespace FluentConsoleApplication
{
    internal class ConsoleText
    {
        public string Text { get; }
        public ConsoleColor? ForegroundColor { get; }

        internal ConsoleText(string text, ConsoleColor? consoleColor)
        {
            Text = text;
            ForegroundColor = consoleColor;
        }
    }
}
