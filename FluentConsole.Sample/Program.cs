using System;
using System.Collections.Generic;

namespace FluentConsoleApplication.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "semcor[color:green]verde[/color]semcor[color:blue]azul [/color] sem cor [invalidtag:]sem cor[/clor] sem cor [color:Cyan]Cyan Cyan[/color] sem cor";//\[.*?\]

            new FluentConsole().Write(a);
            Console.ReadLine();
        }

        public static void GetSubstringByString(string text, string b, string c)
        {
            
        }
    }
}
