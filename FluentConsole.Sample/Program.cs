using System;
using System.Collections.Generic;

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
                new FluentConsole()
                //.Write(a)
                .ReadLine()
                .If("a", (result, console) => { dummy.Name = "tiago"; console.WriteLine("Tiago"); })
                .If("b", (result, console) => dummy.Name = "carlohs")
                .ElseRetry("retry plz")
                .WriteLine(dummy.Name);
            }
        }

        public class Dummy
        {
            public string Name { get; set; }
        }
    }
}
