using System;

namespace FluentConsoleApplication
{
    public sealed partial class FluentConsole : IFluentConsole
    {
        public IFluentConsole ReadLine(Action<string, IFluentConsole> @do)
        {
            string result = Console.ReadLine();
            @do(result, this);
            return this;
        }

        public IFluentConsole ReadKey(Action<ConsoleKey, IFluentConsole> @do)
        {
            ConsoleKey result = Console.ReadKey().Key;
            @do(result, this);
            return this;
        }

        public IFluentConsole ReadKeyLine(Action<ConsoleKey, IFluentConsole> @do)
        {
            ReadKey(@do);
            NewEmptyLine();
            return this;
        }

        public IReadTextResultWrapper ReadLineWithOptions()
        {
            string readText = Console.ReadLine();
            var readResult = new ReadTextResult(readText);

            return new ReadTextResultWrapper(readResult, this);
        }

        public IReadKeyResultWrapper ReadKeyWithOptions()
        {
            ConsoleKey key = Console.ReadKey().Key;
            var readResult = new ReadKeyResult(key);

            return new ReadKeyResultWrapper(readResult, this);
        }

        public IReadKeyResultWrapper ReadKeyLineWithOptions()
        {
            IReadKeyResultWrapper readKeyResultWrapper = ReadKeyWithOptions();
            NewEmptyLine();
            return readKeyResultWrapper;
        }
    }
}