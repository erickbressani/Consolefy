using System;
using System.Collections.Generic;

namespace FluentConsoleApplication
{
    internal class ReadKeyResultWrapper : IReadKeyResultWrapper
    {
        private readonly List<PossibleReadKeyOutcome> _possibleOutcomes;
        internal ReadKeyResult ReadResult { get; }
        internal FluentConsole FluentConsole { get; }
        private bool _alreadyFoundMatch;

        internal ReadKeyResultWrapper(ReadKeyResult readResult, FluentConsole fluentConsole)
        {
            ReadResult = readResult;
            FluentConsole = fluentConsole;
            _possibleOutcomes = new List<PossibleReadKeyOutcome>();
        }

        public IReadKeyResultWrapper If(ConsoleKey result, Action<ConsoleKey, IFluentConsole> @do)
        {
            if (ReadResult.ConsoleKey == result)
            {
                @do(ReadResult.ConsoleKey, FluentConsole);
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleReadKeyOutcome(result, @do));

            return this;
        }

        public IFluentConsole Else(Action<ConsoleKey, IFluentConsole> @do)
        {
            if (!_alreadyFoundMatch)
                @do(ReadResult.ConsoleKey, FluentConsole);

            return FluentConsole;
        }

        public IFluentConsole ElseRetry(string retryText = "")
        {
            while (!_alreadyFoundMatch)
            {
                Console.WriteLine(retryText);
                ConsoleKey readKey = Console.ReadKey().Key;
                var possibleOutcome = _possibleOutcomes.Find(outcome => outcome.ExpectedConsoleKey == readKey);

                if (possibleOutcome != null)
                {
                    possibleOutcome.Do(readKey, FluentConsole);
                    break;
                }
            }

            return FluentConsole;
        }
    }
}
