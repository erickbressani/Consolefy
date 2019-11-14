using System;

namespace Consolefy
{
    internal class ConsoleText
    {
        internal string Text { get; }
        internal ConsoleColor? ForegroundColor { get; }

        internal ConsoleText(string text, ConsoleColor? consoleColor)
        {
            Text = text;
            ForegroundColor = consoleColor;
        }
    }
}
