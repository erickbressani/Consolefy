using System;
using System.Collections.Generic;

namespace FluentConsoleApplication
{
    internal class ReadKeyResultWrapper : IReadKeyResultWrapper
    {
        private readonly List<PossibleReadKeyOutcome> _possibleOutcomes;
        private readonly ReadKeyResult _readResult;
        private readonly FluentConsole _fluentConsole;
        private bool _alreadyFoundMatch;

        internal ReadKeyResultWrapper(ReadKeyResult readResult, FluentConsole fluentConsole)
        {
            _possibleOutcomes = new List<PossibleReadKeyOutcome>();
            _readResult = readResult;
            _fluentConsole = fluentConsole;
        }

        public IReadKeyResultWrapper If(ConsoleKey result, Action<ConsoleKey, IFluentConsole> @do)
        {
            if (_readResult.ConsoleKey == result)
            {
                @do(_readResult.ConsoleKey, _fluentConsole);
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleReadKeyOutcome(result, @do));

            return this;
        }

        public IFluentConsole Else(Action<ConsoleKey, IFluentConsole> @do)
        {
            if (!_alreadyFoundMatch)
                @do(_readResult.ConsoleKey, _fluentConsole);

            return _fluentConsole;
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
                    possibleOutcome.Do(readKey, _fluentConsole);
                    break;
                }
            }

            return _fluentConsole;
        }
    }
}
