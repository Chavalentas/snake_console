using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeTest
{
    public abstract class GameObject
    {
        private int x;

        private int y;

        private int previousX;

        private int previousY;

        public GameObject(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int PreviousX
        {
            get
            {
                return this.previousX;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the x coordinate cannot be less than 0!");
                }

                this.previousX = value;
            }
        }

        public int PreviousY
        {
            get
            {
                return this.previousY;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the y coordinate cannot be less than 0!");
                }

                this.previousY = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the x coordinate cannot be less than 0!");
                }

                this.PreviousX = this.X;
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the y coordinate cannot be less than 0!");
                }

                this.PreviousY = this.Y;
                this.y = value;
            }
        }

        public abstract void AcceptVisitor(IGameObjectVisitor gameObjectVisitor);
    }
}