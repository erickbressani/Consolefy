using System;
using System.Collections.Generic;

namespace Consolefy
{
    internal class ReadKeyResultWrapper : IReadKeyResultWrapper
    {
        private readonly List<PossibleReadKeyOutcome> _possibleOutcomes;
        private readonly ReadKeyResult _readResult;
        private readonly Consolefy _fluentConsole;
        private bool _alreadyFoundMatch;

        internal ReadKeyResultWrapper(ReadKeyResult readResult, Consolefy fluentConsole)
        {
            _possibleOutcomes = new List<PossibleReadKeyOutcome>();
            _readResult = readResult;
            _fluentConsole = fluentConsole;
        }

        public IReadKeyResultWrapper If(ConsoleKey result, Action<ConsoleKey, IConsolefy> @do)
        {
            if (_readResult.ConsoleKey == result)
            {
                @do(_readResult.ConsoleKey, _fluentConsole);
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleReadKeyOutcome(result, @do));

            return this;
        }

        public IReadKeyResultWrapper If(ConsoleKey result, Action<ConsoleKey> @do)
        {
            if (_readResult.ConsoleKey == result)
            {
                @do(_readResult.ConsoleKey);
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleReadKeyOutcome(result, (_, __) => @do(result)));

            return this;
        }

        public IReadKeyResultWrapper If(ConsoleKey result, Action<IConsolefy> @do)
        {
            if (_readResult.ConsoleKey == result)
            {
                @do(_fluentConsole);
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleReadKeyOutcome(result, (_, __) => @do(_fluentConsole)));

            return this;
        }

        public IReadKeyResultWrapper If(ConsoleKey result, Action @do)
        {
            if (_readResult.ConsoleKey == result)
            {
                @do();
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleReadKeyOutcome(result, (_, __) => @do()));

            return this;
        }

        public IConsolefy Else(Action<ConsoleKey, IConsolefy> @do)
        {
            if (!_alreadyFoundMatch)
                @do(_readResult.ConsoleKey, _fluentConsole);

            return _fluentConsole;
        }

        public IConsolefy ElseRetry(string retryText = "")
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
