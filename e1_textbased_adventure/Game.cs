using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace e1_textbased_adventure
{
    class Game
    {
        static string characterName = "";
        float currentScene = 1.0f;
        Dictionary<float, Scene> story = new Dictionary<float, Scene>();
       

        public static void StartGame()
        {
            Console.WriteLine("Welcome to the whimsical region of Avoniath!\nA text-based adventure game set in a medieval world where magic is banished from the kingdom.\nYou're a talented sorcerer, aiming to assassinate the king to end his tyranny and bring magic back to the realm.\n");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Credits");
            Console.WriteLine("4. Exit");
            string input = Console.ReadLine();
            MakeMenuChoice(input);

            static void NameCharacter()
            {
                Dialog("You wouldn't be much of a sorcerer without a proper name, would you? Try to think of a fun name or title!", "blue");
                characterName = Console.ReadLine();
                Console.WriteLine($"Your sorcerer's name is now {characterName}");
            }


            

            static void MakeMenuChoice(string input)
            {
                if (input == "1")
                {
                    Console.Clear();
                    NameCharacter();
                    // Create Save File
                }
                else if (input == "2")
                {
                    // If save file exists, load game
                    Console.WriteLine("Load");
                }

                else if (input == "3")
                {
                    // Credits
                    Console.WriteLine("Creds");
                }

                else if (input == "4")
                {
                    Console.Clear();
                    Dialog("See you next time!", "red");
                    System.Environment.Exit(1);
                }
            }

        }

        private void StoryInitialize()
        {
            InitializeStory storyInitializer = new InitializeStory();
            story = storyInitializer.StoryInitialize();
        }


        void DisplayScene()
        {
            Console.Clear();
            foreach (char character in story[currentScene].Text)
            {
                Dialog(character, "blue");
                Thread.Sleep(60);
            }
            Console.WriteLine("/n ");
            int choiceIndex = 0;

            foreach (Choice choice in story[currentScene].Choices)
            {
                choiceIndex++;
                Console.WriteLine($"{choiceIndex}. {choice.Option}"); 
            }
        }
        float GetPlayerChoice()
        {
            Console.Write("/nEnter your choice: ");
            int choiceIndex;

            while (!int.TryParse(Console.ReadLine(), out choiceIndex) || choiceIndex < 1 || choiceIndex > story[currentScene].Choices.Count)
            {
                Console.WriteLine("invalid input. Please enter a valid option.");
                Console.Write("Enter your choice: ");
            }

            return story[currentScene].Choices[choiceIndex - 1].NextScene;
        }

        void UpdateScene(float choice)
        {
            if (choice >= 1.0f && choice <= 5.0f)
            {
                currentScene = choice;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a valid option.");
            }
        }


        public static void Dialog(string message, string colour)
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

        public static void Dialog(char character, string colour)
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

            Console.Write(character);
            Console.ResetColor();
        }
    }
}
