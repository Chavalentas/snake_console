using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class Rainbow : GameObject
    {
        public Rainbow(int x, int y) : base(x, y)
        {
        }

        public override void AcceptVisitor(IGameObjectVisitor gameObjectVisitor)
        {
            gameObjectVisitor.Visit(this);
        }
    }
}
