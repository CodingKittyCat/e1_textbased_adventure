

using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Avoniath
{
    class Game
    {
        static string characterName = "";

        public static void StartGame()
        {
            Console.WriteLine("Welcome to the whimsical region of Avoniath!\nA text-based adventure game set in a medieval world where magic is banished from the kingdom.\nYou're a talented sorcerer, aiming to assassinate the king to end his tyranny and bring magic back to the realm.\n");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Credits");
            Console.WriteLine("4. Exit");
        }

        static void NameCharacter()
        {
            Dialog("You wouldn't be much of a sorcerer without a proper name, would you? Try to think of a fun name or title!", "blue");
            characterName = Console.ReadLine();
            Console.WriteLine($"Your sorcerer's name is now {characterName}");
        }

        static void Dialog(string message, string colour)
        {
            if (colour== "red")
            { Console.ForegroundColor = ConsoleColor.Red; }
            else if (colour == "green")
            { Console.ForegroundColor = ConsoleColor.Green; }
            else if (colour == "yellow")
            { Console.ForegroundColor = ConsoleColor.Yellow; }
            else if (colour == "blue")
            { Console.ForegroundColor = ConsoleColor.DarkBlue; }
            else
            { Console.ForegroundColor = ConsoleColor.White; }

            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
    class Program
    {
        static void Main()
        {
            Game.StartGame();
            Console.ReadKey();
         
        }
    }
}


