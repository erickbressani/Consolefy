using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentConsoleApplication
{
    public sealed partial class FluentConsole : IFluentConsole
    {
        public IFluentConsole Write(object value)
            => Write(value.ToString());

        public IFluentConsole WriteFormat(string value, params string[] args)
            => Write(string.Format(value, args));

        public IFluentConsole Write(string value)
        {
            WriteText(value);
            return this;
        }

        public IFluentConsole WriteLine(object value)
            => WriteLine(value.ToString());

        public IFluentConsole WriteLineFormat(string value, params string[] args)
            => WriteLine(string.Format(value, args));

        public IFluentConsole WriteLine(string value)
        {
            WriteText(value, newLine: true);
            return this;
        }

        public IFluentConsole NewEmptyLine(int repeat = 0)
        {
            for (int index = 0; index <= repeat; index++)
                Console.WriteLine();

            return this;
        }

        private void WriteText(string value, bool newLine = false)
        {
            if (_currentBackground.HasValue)
                Console.BackgroundColor = _currentBackground.Value;

            if (value.HasColorTag())
            {
                List<ConsoleText> valuesByColor = value.GetValuesByColor();

                foreach (ConsoleText consoleText in valuesByColor)
                {
                    ResetColor();

                    if (consoleText.ForegroundColor.HasValue)
                        Console.ForegroundColor = consoleText.ForegroundColor.Value;

                    if (newLine && consoleText == valuesByColor.Last())
                        Console.WriteLine(consoleText.Text);
                    else
                        Console.Write(consoleText.Text);
                }
            }
            else
            {
                if (newLine)
                    Console.WriteLine(value);
                else
                    Console.Write(value);
            }
        }
    }
}
