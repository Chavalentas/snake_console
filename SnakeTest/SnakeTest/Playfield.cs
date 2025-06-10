using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class Playfield
    {
        private PlayfieldArgs playfieldArgs;

        public Playfield(PlayfieldArgs args)
        {
            this.PlayfieldArgs = args;
        }

        public PlayfieldArgs PlayfieldArgs
        {
            get
            {
                return this.playfieldArgs;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the playfield arguments cannot be null!");
                }

                this.playfieldArgs = value;
            }
        }

        public void Draw()
        {
            this.DrawEdges();
            this.DrawLeftBorder();
            this.DrawRightBorder();
            this.DrawLowerBorder();
            this.DrawUpperBorder();
        }

        private void DrawEdges()
        {
            Console.SetCursorPosition(this.PlayfieldArgs.MinX - 1, this.PlayfieldArgs.MinY - 1);
            Console.Write('╔');
             Console.SetCursorPosition(this.PlayfieldArgs.MaxX + 1, this.PlayfieldArgs.MinY - 1);
            Console.Write('╗');
            Console.SetCursorPosition(this.PlayfieldArgs.MinX - 1, this.PlayfieldArgs.MaxY + 1);
            Console.Write('╚');
            Console.SetCursorPosition(this.PlayfieldArgs.MaxX + 1, this.PlayfieldArgs.MaxY + 1);
            Console.Write('╝');
        }

        private void DrawLeftBorder()
        {
            int amount = this.PlayfieldArgs.MaxY - this.PlayfieldArgs.MinY + 1;

            for (int row = 0; row < amount; row++)
            {
                Console.SetCursorPosition(this.PlayfieldArgs.MinX - 1, this.PlayfieldArgs.MinY + row);
                Console.Write('║');
            }
        }

        private void DrawRightBorder()
        {
            int amount = this.PlayfieldArgs.MaxY - this.PlayfieldArgs.MinY + 1;

            for (int row = 0; row < amount; row++)
            {
                Console.SetCursorPosition(this.PlayfieldArgs.MaxX + 1, this.PlayfieldArgs.MinY + row);
                Console.Write('║');
            }
        }

        private void DrawUpperBorder()
        {
            int amount = this.PlayfieldArgs.MaxX - this.PlayfieldArgs.MinX + 1;

            for (int column = 0; column < amount; column++)
            {
                Console.SetCursorPosition(this.PlayfieldArgs.MinX + column, this.PlayfieldArgs.MinY - 1);
                Console.Write('═');
            }
        }

        private void DrawLowerBorder()
        {
            int amount = this.PlayfieldArgs.MaxX - this.PlayfieldArgs.MinX + 1;

            for (int column = 0; column < amount; column++)
            {
                Console.SetCursorPosition(this.PlayfieldArgs.MinX + column, this.PlayfieldArgs.MaxY + 1);
                Console.Write('═');
            }
        }
    }
}
