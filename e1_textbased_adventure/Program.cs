

using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Avoniath
{
    class Game
    {
        public static void StartGame()
        {
            Console.WriteLine("Welcome to the whimsical region of Avoniath!\nA text-based adventure game set in a medieval world where magic is banished from the kingdom.\nYou're a talented sorcerer, aiming to assassinate the king to end his tyranny and bring magic back to the realm.\n");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Credits");
            Console.WriteLine("4. Exit");
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


