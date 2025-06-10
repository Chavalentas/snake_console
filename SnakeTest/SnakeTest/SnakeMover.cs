using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class SnakeMover
    {
        private Thread moverThread;

        private SnakeMoverThreadArgs moverArgs;

        private Snake snake;

        private StepCounter stepCounter;

        public SnakeMover(Snake snake, StepCounter stepCounter)
        {
            this.moverArgs = new SnakeMoverThreadArgs();
            this.Snake = snake;
            this.stepCounter = stepCounter ?? throw new ArgumentNullException("The value of the step counter cannot be null!");
        }

        public event EventHandler<OnBeforeMovedSnakeEventArgs> OnBeforeMovedSnake;

        public event EventHandler<OnAfterMovedSnakeEventArgs> OnAfterMovedSnake;

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

        public void Start()
        {
            if (this.moverThread != null && !this.moverArgs.Exited)
            {
                return;
            }

            this.moverArgs.Exited = false;
            this.moverThread = new Thread(this.Move);
            this.moverThread.Start(this.moverArgs);
        }

        public void Stop()
        {
            if (this.moverThread == null || this.moverArgs.Exited)
            {
                return;
            }

            this.moverArgs.Exited = true;
            this.moverThread.Join(100);
        }

        public void PressedKeyCallback(object sender, OnPressedKeyEventArgs args)
        {
            switch (args.KeyInformation.Key)
            {
                case ConsoleKey.UpArrow:
                    this.Snake.Direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    this.Snake.Direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    this.Snake.Direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    this.Snake.Direction = Direction.Right;
                    break;
            }
        }

        protected virtual void FireOnBeforeMovedSnake(OnBeforeMovedSnakeEventArgs args)
        {
            this.OnBeforeMovedSnake?.Invoke(this, args);
        }

        protected virtual void FireOnAfterMovedSnake(OnAfterMovedSnakeEventArgs args)
        {
            this.OnAfterMovedSnake?.Invoke(this, args);
        }

        private void Move(object data)
        {
            if (!(data is SnakeMoverThreadArgs))
            {
                return;
            }

            SnakeMoverThreadArgs args = (SnakeMoverThreadArgs)data;

            while (!args.Exited)
            {
                Thread.Sleep(this.Snake.Speed);
                this.FireOnBeforeMovedSnake(new OnBeforeMovedSnakeEventArgs(this.Snake));
                this.Snake.Move();
                this.stepCounter.CurrentValue++;
                this.FireOnAfterMovedSnake(new OnAfterMovedSnakeEventArgs(this.Snake));
            }
        }
    }
}
