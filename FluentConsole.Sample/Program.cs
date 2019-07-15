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

            Console.BackgroundColor = ConsoleColor.Green;

            while (true)
            {
                new FluentConsole()
                //.Write(a)
                .ReadLine()
                .If("a", _ => dummy.Name = "tiago")
                .If("b", _ => dummy.Name = "carlohs")
                .Else(_ => dummy.Name = "aba")
                .WriteLine(dummy.Name);
            }
            
            Console.ReadLine();
        }

        public class Dummy
        {
            public string Name { get; set; }
        }
    }
}
