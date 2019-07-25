using System;

namespace FluentConsoleApplication
{
    public sealed partial class FluentConsole : IFluentConsole
    {
        public IReadTextResultWrapper ReadLine()
        {
            string readText = Console.ReadLine();
            var readResult = new ReadTextResult(readText);

            return new ReadTextResultWrapper(readResult, this);
        }

        public IReadKeyResultWrapper ReadKey()
        {
            ConsoleKey key = Console.ReadKey().Key;
            var readResult = new ReadKeyResult(key);

            return new ReadKeyResultWrapper(readResult, this);
        }
    }
}