using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any button to start.");

            Console.ReadKey();

            Console.CursorVisible = false;

            Game game = new Game();

            game.StartGmae();

            
            
        }
    }
}
