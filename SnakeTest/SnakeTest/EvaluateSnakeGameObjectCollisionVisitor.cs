using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class EvaluateSnakeGameObjectCollisionVisitor : IGameObjectVisitor
    {
        private Snake snake;

        private Random randomGenerator;

        public EvaluateSnakeGameObjectCollisionVisitor(Snake snake, Random random)
        {
            this.Snake = snake;
            this.randomGenerator = random ?? throw new ArgumentNullException("The value of the random generator cannot be null!");
        }

        public event EventHandler<OnRemovedGameObjectEventArgs> OnRemovedGameObject;

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


        public void Visit(Apple apple)
        {
            if (this.Snake.Segments[0].X == apple.X && this.Snake.Segments[0].Y == apple.Y)
            {
                this.FireOnRemovedGameObject(new OnRemovedGameObjectEventArgs(apple));
                this.Snake++;
            }
        }

        public void Visit(SegmentDestructor segmentDestructor)
        {
            if (this.Snake.Segments[0].X == segmentDestructor.X && this.Snake.Segments[0].Y == segmentDestructor.Y)
            {
                this.FireOnRemovedGameObject(new OnRemovedGameObjectEventArgs(segmentDestructor));

                if (this.Snake.Segments.Count > 1)
                {
                    this.Snake--;
                    this.FireOnRemovedGameObject(new OnRemovedGameObjectEventArgs(this.Snake.Segments[this.Snake.Segments.Count - 1]));
                }
            }
        }

        public void Visit(HeadSegment headSegment)
        {
            return;
        }

        public void Visit(BodySegment bodySegment)
        {
            return;
        }

        protected virtual void FireOnRemovedGameObject(OnRemovedGameObjectEventArgs args)
        {
            this.OnRemovedGameObject?.Invoke(this, args);
        }

        public void Visit(Rainbow rainbow)
        {
            if (this.Snake.Segments[0].X == rainbow.X && this.Snake.Segments[0].Y == rainbow.Y)
            {
                this.FireOnRemovedGameObject(new OnRemovedGameObjectEventArgs(rainbow));

                for (int index = 0; index < this.Snake.Segments.Count; index++)
                {
                    this.Snake.Segments[index].SegmentColor = Extensions.GetRandomColor(this.randomGenerator, new ConsoleColor[] { this.Snake.Segments[index].SegmentColor, ConsoleColor.Black });
                }
            }
        }

        public void Visit(Mushroom mushroom)
        {
            if (this.Snake.Segments[0].X == mushroom.X && this.Snake.Segments[0].Y == mushroom.Y)
            {
                this.FireOnRemovedGameObject(new OnRemovedGameObjectEventArgs(mushroom));
                
                if (this.Snake.Speed > 10)
                {
                    this.Snake.Speed -= 10;
                }
            }
        }

        public void Visit(Fly fly)
        {
            if (this.Snake.Segments[0].X == fly.X && this.Snake.Segments[0].Y == fly.Y)
            {
                this.FireOnRemovedGameObject(new OnRemovedGameObjectEventArgs(fly));

                if (this.Snake.Speed < 900)
                {
                    this.Snake.Speed += 10;
                }
            }
        }
    }
}
