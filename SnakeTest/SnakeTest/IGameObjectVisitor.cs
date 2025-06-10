using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public interface IGameObjectVisitor
    {
        void Visit(Apple apple);

        void Visit(Rainbow rainbow);

        void Visit(Mushroom mushroom);

        void Visit(Fly fly);

        void Visit(SegmentDestructor segmentDestructor);

        void Visit(HeadSegment headSegment);

        void Visit(BodySegment bodySegment);
    }
}
