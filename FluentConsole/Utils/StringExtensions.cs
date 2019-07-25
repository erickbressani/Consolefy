using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentConsoleApplication
{
    internal static class StringExtensions
    {
        internal static bool HasColorTag(this string source)
            => Consts.ConsoleColorValues.Any(color => source.Contains(color));

        internal static IEnumerable<ConsoleText> GetValuesByColor(this string source)
        {
            foreach (string splittedByColorTag in source.Split(new string[] { "[color:" }, StringSplitOptions.None))
            {
                foreach (string splittedByTagEnding in splittedByColorTag.Split(new string[] { "[/color]" }, StringSplitOptions.None))
                {
                    string[] splittedBySquareBrackets = splittedByTagEnding.Split(']');

                    ConsoleColor? consoleColor = splittedBySquareBrackets
                        .FirstOrDefault()?
                        .ToConsoleColor();

                    string text;

                    if (consoleColor.HasValue)
                        text = splittedBySquareBrackets[1];
                    else
                        text = splittedByTagEnding;

                    yield return new ConsoleText(text, consoleColor);
                }
            }
        }

        internal static ConsoleColor? ToConsoleColor(this string source)
        {
            switch (source.ToLower())
            {
                case "black":
                    return ConsoleColor.Black;
                case "blue":
                    return ConsoleColor.Blue;
                case "cyan":
                    return ConsoleColor.Cyan;
                case "darkblue":
                    return ConsoleColor.DarkBlue;
                case "darkcyan":
                    return ConsoleColor.DarkCyan;
                case "darkgray":
                    return ConsoleColor.DarkGray;
                case "darkgreen":
                    return ConsoleColor.DarkGreen;
                case "darkmagenta":
                    return ConsoleColor.DarkMagenta;
                case "darkred":
                    return ConsoleColor.DarkRed;
                case "darkyellow":
                    return ConsoleColor.DarkYellow;
                case "gray":
                    return ConsoleColor.Gray;
                case "green":
                    return ConsoleColor.Green;
                case "magenta":
                    return ConsoleColor.Magenta;
                case "red":
                    return ConsoleColor.Red;
                case "white":
                    return ConsoleColor.White;
                case "yellow":
                    return ConsoleColor.Yellow;
                default:
                    return null;
            }
        }
    }
}
