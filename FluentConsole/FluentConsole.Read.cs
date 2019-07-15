using System;

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
    }

    internal class ReadResultWrapper : IReadResultWrapper
    {
        internal ReadResult ReadResult { get; }
        internal FluentConsole FluentConsole { get; }
        private bool _alreadyFoundMatch;

        internal ReadResultWrapper(ReadResult readResult, FluentConsole fluentConsole)
        {
            ReadResult = readResult;
            FluentConsole = fluentConsole;
        }

        public IReadResultWrapper If(string result, Action<string> @do, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (result.Equals(ReadResult.Text, stringComparison))
            {
                @do(ReadResult.Text);
                _alreadyFoundMatch = true;
            }

            return this;
        }

        public FluentConsole Else(Action<string> @do)
        {
            if (!_alreadyFoundMatch)
                @do(ReadResult.Text);
            
            return FluentConsole;
        }

        public FluentConsole ElseRetry()
        {
            return FluentConsole;
        }
    }
}