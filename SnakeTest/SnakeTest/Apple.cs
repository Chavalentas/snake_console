using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeTest
{
    public class Apple : GameObject
    {
        public Apple(int x, int y) : base(x, y)
        {
        }

        public override void AcceptVisitor(IGameObjectVisitor gameObjectVisitor)
        {
            gameObjectVisitor.Visit(this);
        }
    }
}