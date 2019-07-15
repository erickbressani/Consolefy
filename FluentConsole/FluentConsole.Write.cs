using System;

namespace FluentConsoleApplication
{
    public partial class FluentConsole
    {
        public FluentConsole Write(string value)
        {
            WriteText(value);
            return this;
        }

        public FluentConsole WriteLine(string value)
        {
            WriteText(value, newLine: true);
            return this;
        }

        public FluentConsole WithBackgroundColor(ConsoleColor consoleColor)
        {
            _currentBackground = consoleColor;
            return this;
        }

        private void WriteText(string value, bool newLine = false)
        {
            foreach (ConsoleText consoleText in value.GetValuesByColor())
            {
                Console.ResetColor();

                if (consoleText.ForegroundColor.HasValue)
                    Console.ForegroundColor = consoleText.ForegroundColor.Value;

                if (_currentBackground.HasValue)
                    Console.BackgroundColor = _currentBackground.Value;

                if (newLine)
                    Console.WriteLine(consoleText.Text);
                else
                    Console.Write(consoleText.Text);
            }
        }
    }
}
