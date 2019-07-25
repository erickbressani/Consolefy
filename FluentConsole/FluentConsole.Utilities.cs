﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace FluentConsoleApplication
{
    public sealed partial class FluentConsole : IFluentConsole
    {
        private bool _nowLoading;

        private FluentConsole() { }

        public static IFluentConsole Initialize()
             => new FluentConsole();

        public IFluentConsole Clear()
        {
            Console.Clear();
            return this;
        }

        public IFluentConsole Beep()
        {
            Console.Beep();
            return this;
        }

        public IFluentConsole Beep(int frequency, int duration)
        {
            Console.Beep(frequency, duration);
            return this;
        }

        public IFluentConsole SetWindowPosition(int left, int top)
        {
            Console.SetWindowPosition(left, top);
            return this;
        }

        public IFluentConsole SetWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            return this;
        }

        private void Loading(string loadingText = "Loading", int tickMilliseconds = 1000)
        {
            _nowLoading = true;

            Task.Run(() =>
            {
                while (_nowLoading)
                {
                    int cursorTop = (Console.CursorTop - 1) < 0 ? 0 : Console.CursorTop - 1;

                    ClearCurrentConsoleLine();
                    Console.SetCursorPosition(0, cursorTop);
                    Console.WriteLine(loadingText + ".");
                    Console.SetCursorPosition(0, cursorTop);
                    Thread.Sleep(tickMilliseconds);
                    Console.WriteLine(loadingText + "..");
                    Console.SetCursorPosition(0, cursorTop);
                    Thread.Sleep(tickMilliseconds);
                    Console.WriteLine(loadingText + "...");
                    Console.SetCursorPosition(0, cursorTop);
                    Thread.Sleep(tickMilliseconds);
                }
            });
        }

        private void StopLoading()
        {
            _nowLoading = false;
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }

        public IFluentConsole Do(Action action)
        {
            action();
            return this;
        }

        public IFluentConsole DoWithLoading(Action action, string loadingText = "Loading", int tickMilliseconds = 1000)
        {
            Loading(loadingText, tickMilliseconds);
            action();
            StopLoading();
            return this;
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
