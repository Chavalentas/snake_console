using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class Fly : GameObject
    {
        public Fly(int x, int y) : base(x, y)
        {
        }

        public override void AcceptVisitor(IGameObjectVisitor gameObjectVisitor)
        {
            gameObjectVisitor.Visit(this);
        }
    }
}
