using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatziGame
{
    class Program
    {
        static void Main(string[] args)
        {
            YatziGame game = new YatziGame();

            game.play();                                                //Starting the game!

            Console.WriteLine("Thank you for playing! Have a great day! Press Enter to Exit...");
            Console.ReadLine();
        

        }
    }
}
