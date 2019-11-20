using System;
using System.Text;
using System.Threading.Tasks;

namespace Consolefy
{
    public sealed partial class Consolefy : IConsolefy
    {
        private ConsoleColor? _currentBackground;
        private bool _nowLoading;

        private Consolefy() { }

        public static IConsolefy Initialize()
             => new Consolefy();

        public IConsolefy Clear()
        {
            Console.Clear();
            return this;
        }

        public IConsolefy Beep()
        {
            Console.Beep();
            return this;
        }

        public IConsolefy Beep(int frequency, int duration)
        {
            Console.Beep(frequency, duration);
            return this;
        }

        public IConsolefy SetWindowPosition(int left, int top)
        {
            Console.SetWindowPosition(left, top);
            return this;
        }

        public IConsolefy SetWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            return this;
        }

        public IConsolefy WithBackgroundColor(ConsoleColor consoleColor)
        {
            _currentBackground = consoleColor;
            return this;
        }

        public IConsolefy ResetColor()
        {
            Console.ResetColor();
            return this;
        }

        public IConsolefy Do(Action action)
        {
            action();
            return this;
        }

        public IConsolefy DoWithLoading(Action action, string loadingText = "Loading", int tickMilliseconds = 1000)
        {
            Loading(loadingText, tickMilliseconds);
            action();
            StopLoading();
            return this;
        }

        private void Loading(string loadingText = "Loading", int tickMilliseconds = 1000)
        {
            _nowLoading = true;
            NewEmptyLine(repeat: 2);

            int GetCursorTop()
                => (Console.CursorTop - 1) < 0 ? 0 : Console.CursorTop - 1;

            Task.Run(() =>
            {
                while (_nowLoading)
                {
                    int cursorTop = GetCursorTop();

                    ClearCurrentConsoleLine();

                    for (int index = 0; index < 3; index++)
                    {
                        var loading = new StringBuilder();
                        loading.Append(loadingText);

                        for (int dotIndex = 0; dotIndex <= index; dotIndex++)
                            loading.Append(".");

                        Console.SetCursorPosition(0, cursorTop);
                        WriteText(loading.ToString());
                        Task.Delay(tickMilliseconds).Wait();
                    }
                }
            });
        }

        private void StopLoading()
        {
            _nowLoading = false;
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }

        private void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);

            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");

            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
