using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class ConsolePrinter 
    {
        private object locker;

        public ConsolePrinter()
        {
            this.locker = new object();
        }

        public void Print(int x, int y, char character, ConsoleColor color)
        {
            lock (this.locker)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;
                Console.Write(character);
            }
        }

        public void Print(int x, int y, char character, ConsoleColor foreground, ConsoleColor background)
        {
            lock (this.locker)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
                Console.Write(character);
            }
        }

        public void Print(int x, int y, string text)
        {
            lock (this.locker)
            {
                for (int index = 0; index < text.Length; index++)
                {
                    this.Print(x + index, y, text[index], ConsoleColor.Gray);
                }
            }
        }

        public void Print(int x, int y, string text, ConsoleColor foreground, ConsoleColor background)
        {
            lock (this.locker)
            {
                for (int index = 0; index < text.Length; index++)
                {
                    this.Print(x + index, y, text[index], foreground, background);
                }
            }
        }

        public void Erase(int x, int y, int length)
        {
            lock (this.locker)
            {
                for (int index = 0; index < length; index++)
                {
                    this.Print(x + index, y, ' ', ConsoleColor.Gray);
                }
            }
        }
    }
}
