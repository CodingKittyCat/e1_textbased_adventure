# Coding conventions for C#

## Use tabs for indentation 
With indentation, each person can use their own level of indentation, without the confusion of spaces everywhere.

## Use PascalCase for classes, camelCase for variables and functions.
A few examples:

#### Variables
```
string regionName = "Avoniath";
```

#### Classes
```
internal class Adventurer 
{
    public int Id { get; set;}
}
```

#### Functions
```
 private void DisplayMenu()
 {
     // Show the menu, ask for input
     Console.WriteLine("1. New Game");
     Console.WriteLine("2. Continue");
     Console.WriteLine("3. Credits");
     Console.WriteLine("4. Exit");

     Console.WriteLine();
     Console.WriteLine("x. Exit");

     // Get the input
     userInput = Helpers.AskNotNull("Please enter a choice and press <ENTER>: ");

     // Process the input
     HandleUserInput();

     Helpers.Wait();
     Console.Clear();
 }
```

## Semicolons
Use semicolons as much as possible to mark the end of lines

For example:
```
Console.WriteLine("1. New Game");
Console.WriteLine("2. Continue");
Console.WriteLine("3. Credits");
Console.WriteLine("4. Exit");
```