using System;

namespace Consolefy
{
    public sealed partial class Consolefy : IConsolefy
    {
        public IConsolefy ReadLine(Action<string, IConsolefy> @do)
        {
            string result = Console.ReadLine();
            @do(result, this);
            return this;
        }

        public IConsolefy ReadLineAsInt(Action<int, IConsolefy> @do, string retryText = "")
        {
            ReadLineAsParsed<int>(@do, retryText, (value) =>
            {
                if (int.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IConsolefy ReadLineAsLong(Action<long, IConsolefy> @do, string retryText = "")
        {
            ReadLineAsParsed<long>(@do, retryText, (value) =>
            {
                if (long.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IConsolefy ReadLineAsFloat(Action<float, IConsolefy> @do, string retryText = "")
        {
            ReadLineAsParsed<float>(@do, retryText, (value) =>
            {
                if (float.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IConsolefy ReadLineAsDecimal(Action<decimal, IConsolefy> @do, string retryText = "")
        {
            ReadLineAsParsed<decimal>(@do, retryText, (value) =>
            {
                if (decimal.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IConsolefy ReadLineAsGuid(Action<Guid, IConsolefy> @do, string retryText = "")
        {
            ReadLineAsParsed<Guid>(@do, retryText, (value) =>
            {
                if (Guid.TryParse(value, out var parsed))
                    return parsed;

                return null;
            });

            return this;
        }

        public IConsolefy ReadKey(Action<ConsoleKey, IConsolefy> @do)
        {
            ConsoleKey result = Console.ReadKey().Key;
            @do(result, this);
            return this;
        }

        public IConsolefy ReadKeyLine(Action<ConsoleKey, IConsolefy> @do)
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

        private void ReadLineAsParsed<TValueType>(Action<TValueType, IConsolefy> @do, string retryText, Func<string, object> parseMethod)
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