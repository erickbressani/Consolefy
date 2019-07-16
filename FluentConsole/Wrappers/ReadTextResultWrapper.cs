using System;
using System.Collections.Generic;

namespace FluentConsoleApplication
{
    internal class ReadTextResultWrapper : IReadTextResultWrapper
    {
        private readonly List<PossibleReadTextOutcome> _possibleOutcomes;
        internal ReadTextResult ReadResult { get; }
        internal FluentConsole FluentConsole { get; }
        private bool _alreadyFoundMatch;

        internal ReadTextResultWrapper(ReadTextResult readResult, FluentConsole fluentConsole)
        {
            ReadResult = readResult;
            FluentConsole = fluentConsole;
            _possibleOutcomes = new List<PossibleReadTextOutcome>();
        }

        public IReadTextResultWrapper If(string result, Action<string, IFluentConsole> @do, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (result.Equals(ReadResult.Text, stringComparison))
            {
                @do(ReadResult.Text, FluentConsole);
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleReadTextOutcome(result, @do, stringComparison));

            return this;
        }

        public IFluentConsole Else(Action<string, IFluentConsole> @do)
        {
            if (!_alreadyFoundMatch)
                @do(ReadResult.Text, FluentConsole);

            return FluentConsole;
        }

        public IFluentConsole ElseRetry(string retryText = "")
        {
            while (!_alreadyFoundMatch)
            {
                Console.WriteLine(retryText);
                string readText = Console.ReadLine();
                var possibleOutcome = _possibleOutcomes.Find(outcome => outcome.ExpectedResult.Equals(readText, outcome.StringComparison));

                if (possibleOutcome != null)
                {
                    possibleOutcome.Do(readText, FluentConsole);
                    break;
                }
            }

            return FluentConsole;
        }
    }
}
