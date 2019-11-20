# Consolefy
Build your Console Applications fluently faster.

## Nuget
> Install-Package Consolefy -Version 1.1.0

## Main Features:

  - Parse options with retry;
  
  ```csharp
  Consolefy
    .Initialize()
    .WriteLine("Insert an int: ")
    .ReadLineAsInt((value, consolefy) =>
        consolefy.WriteLine($"Value: {value}"), 
        retryText: "Value is not an int, please try again.");
  ```
  
  - Change text and background color easily:
  
  ```csharp
  Consolefy
    .Initialize()
    .WithBackgroundColor(ConsoleColor.Green)
    .WriteLine("This is [color:Blue]Blue[/color] and this is [color:Red]Red[/color]?");
  ```
  
  - Bind Read actions with options and retries 
  
  ```csharp
   Consolefy
    .Initialize()
    .WriteLine("Choose an option:")
    .WriteLine("1. Cook")
    .WriteLine("2. Serve")
    .ReadKeyLineWithOptions()
    .If(ConsoleKey.D1, () => Cook())
    .If(ConsoleKey.D2, () => Serve())
    .ElseRetry();
  ```
  
 - And much more to discover!

## Demo

Simple console application:

![Screenshot](docs/Screenshots/ConsoleDemo.png)

### Default Way 

```csharp
{
  var character = new Character();

  Console.WriteLine("Welcome to character creation:");
  Console.Write("Name:");
  character.Name = Console.ReadLine();
  
  Console.Write("Age:");

  while (true)
  {
      if (int.TryParse(Console.ReadLine(), out var age))
      {
          character.Age = age;
          break;
      }
      else
      {
          Console.WriteLine("Invalid number, please retry");
      }
  }

  while (true)
  {
      Console.Write("Are you a ");
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("(J)edi");
      Console.ResetColor();
      Console.Write(" Or a ");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write("(S)ith");
      Console.ResetColor();
      Console.WriteLine("?");
      var key = Console.ReadKey().Key;

      if (key == ConsoleKey.J)
      {
          character.Alignment = Alignment.Jedi;
          break;
      }
      else if (key == ConsoleKey.S)
      {
          character.Alignment = Alignment.Sith;
          break;
      }
  }

  if (character.Alignment == Alignment.Jedi)
      Console.BackgroundColor = ConsoleColor.Blue;
  else
      Console.BackgroundColor = ConsoleColor.Red;

  Console.WriteLine();
  Console.WriteLine();

  bool _nowLoading = true;

  Task.Run(() =>
  {
      while (_nowLoading)
      {
          int cursorTop = (Console.CursorTop - 1) < 0 ? 0 : Console.CursorTop - 1;

          int currentLineCursor = Console.CursorTop;
          Console.SetCursorPosition(0, Console.CursorTop);

          for (int i = 0; i < Console.WindowWidth; i++)
              Console.Write(" ");

          Console.SetCursorPosition(0, currentLineCursor);

          Console.SetCursorPosition(0, cursorTop);
          Console.WriteLine("Loading.");
          Console.SetCursorPosition(0, cursorTop);
          Thread.Sleep(1000);
          Console.WriteLine("Loading..");
          Console.SetCursorPosition(0, cursorTop);
          Thread.Sleep(1000);
          Console.WriteLine("Loading...");
          Console.SetCursorPosition(0, cursorTop);
          Thread.Sleep(1000);
      }
  });

  DoComplexLogic();
  _nowLoading = false;
  Console.WriteLine($"Welcome to the game {character.Name}!");
}
```

### Fluent Way using Consolefy

```csharp
{
    var character = new Character();

    FluentConsole
        .Initialize()
        .WriteLine("Welcome to character creation:")
        .Write("Name:")
        .ReadLine((name, _) => character.Name = name) //First parameter is the input, second parameter is the FluentConsole itself.
        .Write("Age:")
        .ReadLineAsInt((age, _) => character.Age = age, retryText: "Invalid number, please retry") //Retries until valid input.
        .WriteLine("Are you a [color:Blue](J)edi[/color] or a [color:Red](S)ith[/color]?") //Color tags making the decoration easier.
        .ReadKeyWithOptions()
            .If(ConsoleKey.J, (_, fluentConsole) =>
                {
                    character.Alignment = Alignment.Jedi;
                    fluentConsole.WithBackgroundColor(ConsoleColor.Blue);
                })
            .If(ConsoleKey.S, (_, fluentConsole) =>
                {
                    character.Alignment = Alignment.Sith;
                    fluentConsole.WithBackgroundColor(ConsoleColor.Red);
                })
            .ElseRetry(retryText: "Invalid option, please try again.") //Retries until the key pressed is "J" or "S".
        .DoWithLoading(() => DoComplexLogic(), loadingText: "Loading") //Writes an animated "Loading..." until execution is complete.
        .WriteLine($"Welcome to the game {character.Name}!");
}
```
