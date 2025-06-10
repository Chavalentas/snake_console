using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class PlayfieldArgs
    {
        private int minX;

        private int minY;

        private int maxX;

        private int maxY;

        public int MinX
        {
            get
            {
                return this.minX;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the minimal x coordinate cannot be less than 0!");
                }

                if (value > Console.LargestWindowWidth)
                {
                    throw new ArgumentOutOfRangeException("The value of the minimal x coordinate cannot be larger than the maximal window width!");
                }

                this.minX = value;
            }
        }

        public int MinY
        {
            get
            {
                return this.minY;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the minimal x coordinate cannot be less than 0!");
                }

                if (value > Console.LargestWindowHeight)
                {
                    throw new ArgumentOutOfRangeException("The value of the minimal x coordinate cannot be larger than the maximal window height!");
                }

                this.minY = value;
            }
        }

        public int MaxX
        {
            get
            {
                return this.maxX;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the minimal x coordinate cannot be less than 0!");
                }

                if (value > Console.LargestWindowWidth)
                {
                    throw new ArgumentOutOfRangeException("The value of the minimal x coordinate cannot be larger than the maximal window width!");
                }

                this.maxX = value;
            }
        }

        public int MaxY
        {
            get
            {
                return this.maxY;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the minimal x coordinate cannot be less than 0!");
                }

                if (value > Console.LargestWindowHeight)
                {
                    throw new ArgumentOutOfRangeException("The value of the minimal x coordinate cannot be larger than the maximal window height!");
                }

                this.maxY = value;
            }
        }
    }
}
