using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeTest
{
    public abstract class Segment : GameObject
    {
        public Segment(int x, int y) : base(x, y)
        {
            this.SegmentColor = ConsoleColor.Gray;
        }

        public ConsoleColor SegmentColor
        {
            get;
            set;
        }
    }
}