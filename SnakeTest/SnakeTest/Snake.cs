using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeTest
{
    public class Snake
    {
        private List<Segment> segments;

        private int headStartX;

        private int headStartY;

        private int speed;

        public Snake(int headStartX, int headStartY, int speed)
        {
            this.Segments = new List<Segment>();
            this.Speed = speed;
            this.headStartX = headStartX >= 0 ? this.headStartX = headStartX : throw new ArgumentOutOfRangeException("The value of the head start x coordinate cannot be less than 0!");
            this.headStartY = headStartY >= 0 ? this.headStartY = headStartY : throw new ArgumentOutOfRangeException("The value of the head start y coordinate cannot be less than 0!");
            this.Segments.Add(new HeadSegment(this.headStartX, this.headStartY));
        }

        public List<Segment> Segments
        {
            get
            {
                return this.segments;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the segments cannot be null!");
                }

                this.segments = value;
            }
        }

        public Direction Direction
        {
            get;
            set;
        }

       public int Speed
        {
            get
            {
                return this.speed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the speed cannot be less or equal to 0!");
                }

                this.speed = value; 
            }
        }

        public void Move()
        {
            switch (this.Direction)
            {
                case Direction.Up:
                    this.MoveUp();
                    break;
                case Direction.Down:
                    this.MoveDown();
                    break;
                case Direction.Left:
                    this.MoveLeft();
                    break;
                case Direction.Right:
                    this.MoveRight();
                    break;
            }
        }

        public static Snake operator ++(Snake snake)
        {
            if (snake.Segments.Count <= 0)
            {
                throw new ArgumentOutOfRangeException("The length of the snake cannot be 0 or less!");
            }

            Segment lastSegment = snake.Segments[snake.Segments.Count - 1];
            snake.Segments.Add(new BodySegment(lastSegment.PreviousX, lastSegment.PreviousY));

            return snake;
        }

        public static Snake operator --(Snake snake)
        {
            if (snake.Segments.Count <= 1)
            {
                throw new ArgumentOutOfRangeException("A snake with the length of 1 cannot be shortened!");
            }

            snake.Segments.RemoveAt(snake.Segments.Count - 1);

            return snake;
        }

        private void MoveUp()
        {
            if (this.Segments.Count > 1)
            {
                this.MoveBodySegments();
            }

            this.Segments[0].Y--;
        }

        private void MoveDown()
        {
            if (this.Segments.Count > 1)
            {
                this.MoveBodySegments();
            }

            this.Segments[0].Y++;
        }

        private void MoveLeft()
        {
            if (this.Segments.Count > 1)
            {
                this.MoveBodySegments();
            }

            this.Segments[0].X--;
        }

        private void MoveRight()
        {
            if (this.Segments.Count > 1)
            {
                this.MoveBodySegments();
            }

            this.Segments[0].X++;
        }

        private void MoveBodySegments()
        {
            for (int index = this.Segments.Count - 1; index > 0; index--)
            {
                this.Segments[index].X = this.Segments[index - 1].X;
                this.Segments[index].Y = this.Segments[index - 1].Y;
            }
        }
    }
}