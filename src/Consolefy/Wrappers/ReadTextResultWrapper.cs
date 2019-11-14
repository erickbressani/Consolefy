using System;
using System.Collections.Generic;

namespace Consolefy
{
    internal class ReadTextResultWrapper : IReadTextResultWrapper
    {
        private readonly List<PossibleReadTextOutcome> _possibleOutcomes;
        private readonly ReadTextResult _readResult;
        private readonly Consolefy _fluentConsole;
        private bool _alreadyFoundMatch;

        internal ReadTextResultWrapper(ReadTextResult readResult, Consolefy fluentConsole)
        {
            _possibleOutcomes = new List<PossibleReadTextOutcome>();
            _readResult = readResult;
            _fluentConsole = fluentConsole;
        }

        public IReadTextResultWrapper If(string result, Action<string, IConsolefy> @do, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (result.Equals(_readResult.Text, stringComparison))
            {
                @do(_readResult.Text, _fluentConsole);
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleReadTextOutcome(result, @do, stringComparison));

            return this;
        }

        public IConsolefy Else(Action<string, IConsolefy> @do)
        {
            if (!_alreadyFoundMatch)
                @do(_readResult.Text, _fluentConsole);

            return _fluentConsole;
        }

        public IConsolefy ElseRetry(string retryText = "")
        {
            while (!_alreadyFoundMatch)
            {
                _fluentConsole.NewEmptyLine();
                Console.WriteLine(retryText);
                string readText = Console.ReadLine();
                var possibleOutcome = _possibleOutcomes.Find(outcome => outcome.ExpectedResult.Equals(readText, outcome.StringComparison));

                if (possibleOutcome != null)
                {
                    possibleOutcome.Do(readText, _fluentConsole);
                    break;
                }
            }

            return _fluentConsole;
        }
    }
}
