using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class DrawGameObjectVisitor : IGameObjectVisitor
    {
        private ConsolePrinter consolePrinter;

        public DrawGameObjectVisitor(ConsolePrinter consolePrinter)
        {
            this.consolePrinter = consolePrinter ?? throw new ArgumentNullException("The value of the console printer cannot be null!");
        }

        public void Visit(Apple apple)
        {
            this.consolePrinter.Print(apple.X, apple.Y, 'a', ConsoleColor.Red);
        }

        public void Visit(SegmentDestructor segmentDestructor)
        {
            this.consolePrinter.Print(segmentDestructor.X, segmentDestructor.Y, 'Ω', ConsoleColor.Green);
        }

        public void Visit(HeadSegment headSegment)
        {
            this.consolePrinter.Print(headSegment.X, headSegment.Y, 'X', headSegment.SegmentColor);
        }

        public void Visit(BodySegment bodySegment)
        {
            this.consolePrinter.Print(bodySegment.X, bodySegment.Y, '+', bodySegment.SegmentColor);
        }

        public void Visit(Rainbow rainbow)
        {
            this.consolePrinter.Print(rainbow.X, rainbow.Y, 'r', ConsoleColor.Blue);
        }

        public void Visit(Mushroom mushroom)
        {
            this.consolePrinter.Print(mushroom.X, mushroom.Y, 'm', ConsoleColor.Cyan);
        }

        public void Visit(Fly fly)
        {
            this.consolePrinter.Print(fly.X, fly.Y, 'f', ConsoleColor.Gray);
        }
    }
}
