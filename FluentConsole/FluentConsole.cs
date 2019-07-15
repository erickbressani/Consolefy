using System;

namespace FluentConsoleApplication
{
    public class FluentConsole
    {
        public FluentConsole Write(string value)
        {
            foreach (ConsoleText consoleText in value.GetValuesByColor())
            {
                Console.ResetColor();

                if (consoleText.ForegroundColor.HasValue)
                    Console.ForegroundColor = consoleText.ForegroundColor.Value;

                Console.Write(consoleText.Text);
            }

            return this;
        }
    }
}
