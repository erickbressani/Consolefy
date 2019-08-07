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

        public IFluentConsole ReadLineAsInt(Action<int, IFluentConsole> @do, string retryText = "")
        {
            ReadLineAsParsed<int>(@do, retryText, (value) =>
            {
                if (int.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IFluentConsole ReadLineAsLong(Action<long, IFluentConsole> @do, string retryText = "")
        {
            ReadLineAsParsed<long>(@do, retryText, (value) =>
            {
                if (long.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IFluentConsole ReadLineAsFloat(Action<float, IFluentConsole> @do, string retryText = "")
        {
            ReadLineAsParsed<float>(@do, retryText, (value) =>
            {
                if (float.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IFluentConsole ReadLineAsDecimal(Action<decimal, IFluentConsole> @do, string retryText = "")
        {
            ReadLineAsParsed<decimal>(@do, retryText, (value) =>
            {
                if (decimal.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IFluentConsole ReadLineAsGuid(Action<Guid, IFluentConsole> @do, string retryText = "")
        {
            ReadLineAsParsed<Guid>(@do, retryText, (value) =>
            {
                if (Guid.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

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

        public IReadTextResultWrapper ReadLineAsIntWithOptions(string retryText = "")
        {
            return ReadLineAsParsedWithOptions(
                (value) => int.TryParse(value, out var parsed),
                retryText);
        }

        public IReadTextResultWrapper ReadLineAsLongWithOptions(string retryText = "")
        {
            return ReadLineAsParsedWithOptions(
                (value) => long.TryParse(value, out var parsed),
                retryText);
        }

        public IReadTextResultWrapper ReadLineAsFloatWithOptions(string retryText = "")
        {
            return ReadLineAsParsedWithOptions(
                (value) => float.TryParse(value, out var parsed),
                retryText);
        }

        public IReadTextResultWrapper ReadLineAsDecimalWithOptions(string retryText = "")
        {
            return ReadLineAsParsedWithOptions(
                (value) => decimal.TryParse(value, out var parsed),
                retryText);
        }

        public IReadTextResultWrapper ReadLineAsGuidWithOptions(string retryText = "")
        {
            return ReadLineAsParsedWithOptions(
                (value) => Guid.TryParse(value, out var parsed),
                retryText);
        }

        private IReadTextResultWrapper ReadLineAsParsedWithOptions(Func<string, bool> parseMethod, string retryText = "")
        {
            while (true)
            {
                string readText = Console.ReadLine();

                if (parseMethod(readText))
                {
                    var readResult = new ReadTextResult(readText);
                    return new ReadTextResultWrapper(readResult, this);
                }
                else if (!string.IsNullOrEmpty(retryText))
                {
                    WriteText(retryText);
                }
            }
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

        private void ReadLineAsParsed<TValueType>(Action<TValueType, IFluentConsole> @do, string retryText, Func<string, object> parseMethod)
        {
            while (true)
            {
                string result = Console.ReadLine();
                object maybeParsed = parseMethod(result);

                if (maybeParsed is TValueType parsed)
                {
                    @do(parsed, this);
                    break;
                }
                else if (!string.IsNullOrEmpty(retryText))
                {
                    WriteText(retryText, newLine: true);
                }
            }
        }
    }
}