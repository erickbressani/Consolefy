using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentConsoleApplication
{
    public partial class FluentConsole
    {
        public IReadResultWrapper ReadLine()
        {
            string readText = Console.ReadLine();
            var readResult = new ReadResult(readText);

            return new ReadResultWrapper(readResult, this);
        }
    }

    public interface IReadResultWrapper
    {
        IReadResultWrapper If(string result, Action<string> @do, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase);
        FluentConsole Else(Action<string> @do);
        FluentConsole ElseRetry(string retryText = "");
    }

    internal class ReadResultWrapper : IReadResultWrapper
    {
        internal ReadResult ReadResult { get; }
        internal FluentConsole FluentConsole { get; }
        private bool _alreadyFoundMatch;
        private List<PossibleOutcome> _possibleOutcomes;

        internal ReadResultWrapper(ReadResult readResult, FluentConsole fluentConsole)
        {
            ReadResult = readResult;
            FluentConsole = fluentConsole;
            _possibleOutcomes = new List<PossibleOutcome>();
        }

        public IReadResultWrapper If(string result, Action<string> @do, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (result.Equals(ReadResult.Text, stringComparison))
            {
                @do(ReadResult.Text);
                _alreadyFoundMatch = true;
            }

            _possibleOutcomes.Add(new PossibleOutcome(result, @do, stringComparison));

            return this;
        }

        public FluentConsole Else(Action<string> @do)
        {
            if (!_alreadyFoundMatch)
                @do(ReadResult.Text);
            
            return FluentConsole;
        }

        public FluentConsole ElseRetry(string retryText = "")
        {
            while (!_alreadyFoundMatch)
            {
                Console.WriteLine(retryText);
                string readText = Console.ReadLine();
                var possibleOutcome = _possibleOutcomes.FirstOrDefault(outcome => outcome.ExpectedResult.Equals(readText, outcome.StringComparison));

                if (possibleOutcome != null)
                {
                    possibleOutcome.Do(readText);
                    break;
                }
            }

            return FluentConsole;
        }
    }

    internal class PossibleOutcome
    {
        internal string ExpectedResult { get; }
        internal Action<string> Do { get; }
        internal StringComparison StringComparison { get; }

        public PossibleOutcome(string expectedResult, Action<string> @do, StringComparison stringComparison)
        {
            ExpectedResult = expectedResult;
            Do = @do;
            StringComparison = stringComparison;
        }
    }
}