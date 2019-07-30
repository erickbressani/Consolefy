﻿using System;

namespace FluentConsoleApplication
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
