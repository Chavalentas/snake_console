using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameScoreBox 
    {
        private int pointCount;

        private int x;

        private int y;

        private int frameWidth;

        private int frameHeight;

        private ConsolePrinter consolePrinter;

        public GameScoreBox(int x, int y, ConsolePrinter consolePrinter)
        {
            this.X = x;
            this.Y = y;
            this.frameWidth = 20;
            this.frameHeight = 10;
            this.consolePrinter = consolePrinter ?? throw new ArgumentNullException("The value of the console printer cannot be null!");
        }

        public int X
        {
            get
            {
                return this.x;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the x coordinate cannot be less than 0!");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the y coordinate cannot be less than 0!");
                }

                this.y = value;
            }
        }

        public int PointCount
        {
            get
            {
                return this.pointCount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the point count cannot be less than 0!");
                }

                this.pointCount = value;
            }
        }

        public void EvaluatePointsCount(Snake snake)
        {
            if (snake.Segments.Count - 1 > this.PointCount)
            {
                this.consolePrinter.Erase(this.X + 1 + "Score: ".Length, this.Y + 1, this.PointCount.ToString().Length);
                this.PointCount = snake.Segments.Count - 1;
                this.consolePrinter.Print(this.X + 1 + "Score: ".Length, this.Y + 1, this.PointCount.ToString());
            }

            if (snake.Segments.Count - 1 < this.PointCount)
            {
                this.consolePrinter.Erase(this.X + 1 + "Score: ".Length, this.Y + 1, this.PointCount.ToString().Length);
                this.PointCount = snake.Segments.Count - 1;
                this.consolePrinter.Print(this.X + 1 + "Score: ".Length, this.Y + 1, this.PointCount.ToString());
            }
        }

        public void Draw()
        {
            this.DrawFrame();
            this.DrawHeader();
        }

        private void DrawFrame()
        {
            this.DrawEdges();
            this.DrawLowerBorder();
            this.DrawUpperBorder();
            this.DrawLeftBorder();
            this.DrawRightBorder();
        }

        private void DrawHeader()
        {
            Console.SetCursorPosition(this.X + 1, this.Y + 1);
            Console.Write("Score: 0");
        }

        private void DrawLowerBorder()
        {
            for (int index = 0; index < this.frameWidth; index++)
            {
                Console.SetCursorPosition(this.X + index + 1, this.Y + this.frameHeight + 1);
                Console.Write("═");
            }
        }

        private void DrawUpperBorder()
        {
            for (int index = 0; index < this.frameWidth; index++)
            {
                Console.SetCursorPosition(this.X + index + 1, this.Y);
                Console.Write("═");
            }
        }

        private void DrawLeftBorder()
        {
            for (int index = 0; index < this.frameHeight; index++)
            {
                Console.SetCursorPosition(this.X, this.Y + index + 1);
                Console.Write("║");
            }
        }

        private void DrawRightBorder()
        {
            for (int index = 0; index < this.frameHeight; index++)
            {
                Console.SetCursorPosition(this.X + this.frameWidth + 1, this.Y + index + 1);
                Console.Write("║");
            }
        }

        private void DrawEdges()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("╔");
            Console.SetCursorPosition(this.X + this.frameWidth + 1, this.Y);
            Console.Write("╗");
            Console.SetCursorPosition(this.X, this.Y + this.frameHeight + 1);
            Console.Write("╚");
            Console.SetCursorPosition(this.X + this.frameWidth + 1, this.Y + this.frameHeight + 1);
            Console.Write("╝");
        }
    }
}
