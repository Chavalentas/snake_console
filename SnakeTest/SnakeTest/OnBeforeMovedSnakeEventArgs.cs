using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class OnBeforeMovedSnakeEventArgs
    {
        private Snake snake;

        public OnBeforeMovedSnakeEventArgs(Snake snake)
        {
            this.Snake = snake;
        }

        public Snake Snake
        {
            get
            {
                return this.snake;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the snake cannot be null!");
                }

                this.snake = value;
            }
        }
    }
}
