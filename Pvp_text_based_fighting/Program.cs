using System;

namespace Pvp_text_based_fighting
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
            Console.ReadKey();
        }
    }
}
