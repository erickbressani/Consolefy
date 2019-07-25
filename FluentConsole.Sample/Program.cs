using System;
using System.Collections.Generic;
using System.Threading;

namespace FluentConsoleApplication.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "semcor[color:green]verde[/color]semcor[color:blue]azul [/color] sem cor [invalidtag:]sem cor[/clor] sem cor [color:Cyan]Cyan Cyan[/color] sem cor";//\[.*?\]

            var dummy = new Dummy { Name = "aaa" };


            //Console.BackgroundColor = ConsoleColor.Green;

            while (true)
            {
                FluentConsole
                    .Initialize()
                    .DoWithLoading(() => test("a"))
                    .ReadLine()
                    .If("a", (result, console) => { dummy.Name = "tiago"; console.WriteLine("Tiago"); })
                    .If("b", (result, console) => dummy.Name = "carlohs")
                    .ElseRetry("retry plz")
                    .WriteLine("a")
                    .WriteLine("b")
                    .WriteLine("c");

                //FluentConsole
                //    .Initialize()
                //    .ReadLine()
                //    .If("a", (result, console) => { dummy.Name = "tiago"; console.WriteLine("Tiago"); })
                //    .If("b", (result, console) => dummy.Name = "carlohs")
                //    .ElseRetry("retry plz")
                //    .WriteLine(dummy.Name);
            }
        }

        static void test(string b)
        {
            Thread.Sleep(3000);
        }

        public class Dummy
        {
            public string Name { get; set; }
        }
    }
}
