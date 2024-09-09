using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace e1_textbased_adventure
{
    class Game
    {
        List<string> commands = new List<string>();
        Dictionary<float, Scene> story = new Dictionary<float, Scene>();

        string characterName = "";
        float currentScene = 1.0f;

        public Game()
        {
            StoryInitialize();
            commands.Add("save-game");
            commands.Add("help");
        }

        public void StartGame()
        {
            while(true)
            { 
                Dialog("Welcome to the whimsical region of Avoniath!\nA text-based adventure game set in a medieval world where magic is banished from the kingdom.\nYou're a talented sorcerer, aiming to assassinate the king to end his tyranny and bring magic back to the realm.\n", "blue");
                Dialog("       _                        \r\n       \\`*-.                    \r\n        )  _`-.                 \r\n       .  : `. .                \r\n       : _   '  \\               \r\n       ; *` _.   `*-._          \r\n       `-.-'          `-.       \r\n         ;       `       `.     \r\n         :.       .        \\    \r\n         . \\  .   :   .-'   .   \r\n         '  `+.;  ;  '      :   \r\n         :  '  |    ;       ;-. \r\n         ; '   : :`-:     _.`* ;\r\n      .*' /  .*' ; .*`- +'  `*' \r\n      `*-*   `*-*  `*-*'\n", "cyan");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Load Game");
                Console.WriteLine("3. Credits");
                Console.WriteLine("4. Exit");
                string input = Console.ReadLine();
                Console.Clear();
                MakeMenuChoice(input);

            }
        }

        void NameCharacter()
        {
            while (true)
            {
                if (characterName == null || characterName == "")
                {
                Dialog("You wouldn't be much of a sorcerer without a proper name, would you? Try to think of a fun name or title!", "blue");
                characterName = Console.ReadLine();

                }
                else 
                {
                    Console.WriteLine($"Your sorcerer's name is now {characterName}\nPress any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }

        }

        void MakeMenuChoice(string input)
        {
            if (input == "1")
            {
                Console.Clear();
                NameCharacter();

                StartAdventure();
            }
            else if (input == "2")
            {
                LoadGame();
            }
            else if (input == "3")
            {
                Console.WriteLine("Creds");
            }
            else if (input == "4")
            {
                Console.Clear();
                Dialog("                          See you next time! \n\n" + "                      /^--^\\     /^--^\\     /^--^\\\r\n                      \\____/     \\____/     \\____/\r\n                     /      \\   /      \\   /      \\\r\n                    |        | |        | |        |\r\n                     \\__  __/   \\__  __/   \\__  __/\r\n|^|^|^|^|^|^|^|^|^|^|^|^\\ \\^|^|^|^/ /^|^|^|^|^\\ \\^|^|^|^|^|^|^|^|^|^|^|^|\r\n| | | | | | | | | | | | |\\ \\| | |/ /| | | | | | \\ \\ | | | | | | | | | | |\r\n########################/ /######\\ \\###########/ /#######################\r\n| | | | | | | | | | | | \\/| | | | \\/| | | | | |\\/ | | | | | | | | | | | |\r\n|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|", "red");
                Environment.Exit(1);
            }
        }

        public void StartAdventure()
        {
            while (true)
            {
                DisplayScene();
                float playerChoice = GetPlayerChoice();
                UpdateScene(playerChoice);
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
                Thread.Sleep(30);
            }


            Console.WriteLine("\n ");
            int choiceIndex = 0;

            foreach (Choice choice in story[currentScene].Choices)
            {
                choiceIndex++;
                Console.WriteLine($"{choiceIndex}. {choice.Option}");
            }
        }

        float GetPlayerChoice()
        {
            bool makingChoice = true;
            string choice = "";
            int choiceIndex = 0;

            while (true)
            {
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine().ToLower();

                if (CommandList(choice))
                {
                    continue;
                };
           
                if (int.TryParse(choice, out choiceIndex) && choiceIndex > 0 && choiceIndex <= story[currentScene].Choices.Count)
                {
                    return story[currentScene].Choices[choiceIndex - 1].NextScene; ;
                }
                Dialog("\n-=-\nInvalid Choice. Please pick enter a valid number\n-=-\n", "red");
            }
        }

        void UpdateScene(float choice)
        {
            if (choice >= 1.0f && choice <= 5.0f)
            {
                currentScene = choice;
                return;
            }
            Console.WriteLine("Invalid choice. Please choose a valid option.");
        }

        public void Dialog(string message, string colour)
        {
            if (colour == "red")
            { Console.ForegroundColor = ConsoleColor.Red; }
            else if (colour == "green")
            { Console.ForegroundColor = ConsoleColor.Green; }
            else if (colour == "yellow")
            { Console.ForegroundColor = ConsoleColor.Yellow; }
            else if (colour == "blue")
            { Console.ForegroundColor = ConsoleColor.DarkBlue; }
            else if (colour == "cyan")
            { Console.ForegroundColor = ConsoleColor.Cyan; }
            else
            { Console.ForegroundColor = ConsoleColor.White; }

            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Dialog(char character, string colour)
        {
            if (colour == "red")
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

        public void SaveGame()
        {
            StreamWriter file = new StreamWriter("save.txt");
            file.WriteLine(currentScene);
            file.Close();
        }

        public void LoadGame()
        {
            if (File.Exists("save.txt"))
            {
                float.TryParse(File.ReadAllText("save.txt"), out currentScene);
                StartAdventure();
                return;
            }
                StartGame();
        }

        public bool CommandList(string choice)
        {
            foreach (string command in commands)
            {
                if (choice == command)
                {
                    switch (choice)
                    {
                        case "help":
                            GetInstructions();
                            break;
                        case "save-game":
                            SaveCommand();
                            break;
                        default:
                            Console.WriteLine("This is not a valid input. Please retry.");
                            break;
                    }
                    return true;
                }
            }
            return false;
        }
        public void GetInstructions()
        {
            Console.Clear();
            Console.WriteLine("Instructions\n");
            foreach (char character in story[currentScene].Instructions)
            {
                Dialog(character, "red");
                Thread.Sleep(60);
            }
            Console.WriteLine("\n\nPress any key to continue.");
            Console.ReadKey();
            DisplayScene();
        }

        public void SaveCommand()
        {
            Console.Clear();
            SaveGame();
            Console.WriteLine("Save Complete. Press any key to continue.");
            Console.ReadKey();
            DisplayScene();
        }
    }


}
