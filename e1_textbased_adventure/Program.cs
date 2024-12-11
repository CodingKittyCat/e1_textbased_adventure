using System;

namespace e1_textbased_adventure
{
    class Program
    {
        static void Main()
        {
            Game gameInstance = new Game();
            gameInstance.StartGame();
            Console.ReadKey();
        }
    }
}
