using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            Application application = new Application();
            application.Start();
        }
    }
}
