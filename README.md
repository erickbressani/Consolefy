# FluentConsole
Build your Console Applications easily.

## Nuget
TODO

## Demo

Simple console application:

![Screenshot](Screenshot/ConsoleDemo.png)

### Default Way 

```csharp
 while (true)
            {
                Console.Write("Are you a ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("(J)edi");
                Console.ResetColor();
                Console.Write(" Or a ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(S)ith");
