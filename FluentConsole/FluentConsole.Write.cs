using System;

namespace FluentConsoleApplication
{
    public partial class FluentConsole : IFluentConsole
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

        public IFluentConsole Clear()
        {
            Console.Clear();
            return this;
        }

        private void WriteText(string value, bool newLine = false)
        {
            if (value.HasColorTag())
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
