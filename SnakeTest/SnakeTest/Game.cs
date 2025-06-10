using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class Game
    {
        private ConsolePrinter consolePrinter;

        private Snake snake;

        private Random random;

        private Playfield playfield;

        private StepCounter snakeStepCounter;

        private SnakeMover snakeMover;

        private List<GameObject> gameObjects;

        private SnakeCollisionEvaluator collisionEvaluator;

        private KeyboardWatcher keyboardWatcher;

        private SnakeStepsAmountEvaluator snakeStepsAmountEvaluator;

        private GameObjectCreator gameObjectCreator;

        private GameScoreBox scoreBox;

        public Game()
        {
            this.consolePrinter = new ConsolePrinter();

            PlayfieldArgs playfieldArgs = new PlayfieldArgs()
            {
                MinX = 2,
                MaxX = Console.WindowWidth - 30,
                MinY = 2,
                MaxY = Console.WindowHeight - 3
            };

            this.GameObjects = new List<GameObject>();
            this.keyboardWatcher = new KeyboardWatcher();
            this.Playfield = new Playfield(playfieldArgs);
            this.scoreBox = new GameScoreBox(this.Playfield.PlayfieldArgs.MaxX + 2, this.Playfield.PlayfieldArgs.MinY, this.consolePrinter);
            this.random = new Random();
            this.Snake = this.CreateSnake();
            this.snakeStepCounter = new StepCounter();
            this.gameObjectCreator = new GameObjectCreator(this.random, this.Playfield, this.Snake, this.GameObjects);
            this.snakeStepsAmountEvaluator = new SnakeStepsAmountEvaluator(this.snakeStepCounter, this.random, this.gameObjectCreator, this.GameObjects);
            this.snakeStepsAmountEvaluator.OnNewGameObject += this.NewGameObjectCallback;
            this.snakeMover = new SnakeMover(this.Snake, this.snakeStepCounter);
            this.snakeMover.OnAfterMovedSnake += this.AfterMovedSnakeCallback;
            this.snakeMover.OnBeforeMovedSnake += this.BeforeMovedSnakeCallback;
            this.keyboardWatcher.OnPressedKey += this.snakeMover.PressedKeyCallback;
            this.collisionEvaluator = new SnakeCollisionEvaluator(this.Snake, this.GameObjects, this.Playfield, this.random);
            this.collisionEvaluator.OnRemovedGameObject += this.RemovedGameObjectEventArgs;
        }

        public event EventHandler<OnFinishedGameEventArgs> OnFinishedGame;

        public List<GameObject> GameObjects
        {
            get
            {
                return this.gameObjects;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the game objects cannot be null!");
                }

                this.gameObjects = value;
            }
        }

        public Playfield Playfield
        {
            get
            {
                return this.playfield;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the playfield cannot be null!");
                }

                this.playfield = value;
            }
        }

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
            this.Playfield.Draw();
            this.scoreBox.Draw();
            this.keyboardWatcher.Start();
            this.snakeMover.Start();
        }

        public void Stop()
        {
            GameScore gameScore = new GameScore(this.scoreBox.PointCount, DateTime.Now);
            this.snakeMover.Stop();
            this.keyboardWatcher.Stop();
            Console.Clear();
            this.FireOnFinishedGame(new OnFinishedGameEventArgs(gameScore));
        }

        protected virtual void FireOnFinishedGame(OnFinishedGameEventArgs args)
        {
            this.OnFinishedGame?.Invoke(this, args);
        }

        private void BeforeMovedSnakeCallback(object sender, OnBeforeMovedSnakeEventArgs args)
        {
            List<Segment> segments = args.Snake.Segments;

            foreach (var segment in segments)
            {
                EraseGameObjectVisitor eraseGameObjectVisitor = new EraseGameObjectVisitor(this.consolePrinter);
                segment.AcceptVisitor(eraseGameObjectVisitor);
            }
        }

        private void AfterMovedSnakeCallback(object sender, OnAfterMovedSnakeEventArgs args)
        {
            try
            {
                this.collisionEvaluator.Evaluate();
            }
            catch (FatalCollisionException ex)
            {
                this.Stop();
                return;
            }

            List<Segment> segments = args.Snake.Segments;
            this.scoreBox.EvaluatePointsCount(args.Snake);

            foreach (var segment in segments)
            {
                DrawGameObjectVisitor drawGameObjectVisitor = new DrawGameObjectVisitor(this.consolePrinter);
                segment.AcceptVisitor(drawGameObjectVisitor);
            }
        }

        private void NewGameObjectCallback(object sender, OnNewGameObjectEventArgs args)
        {
            DrawGameObjectVisitor drawGameObjectVisitor = new DrawGameObjectVisitor(this.consolePrinter);
            args.GameObject.AcceptVisitor(drawGameObjectVisitor);
        }

        private void RemovedGameObjectEventArgs(object sender, OnRemovedGameObjectEventArgs args)
        {
            this.GameObjects.Remove(args.GameObject);   
            EraseGameObjectVisitor eraseGameObjectVisitor = new EraseGameObjectVisitor(this.consolePrinter);
            args.GameObject.AcceptVisitor(eraseGameObjectVisitor);
        }

        private Snake CreateSnake()
        {
            int x = this.random.Next(this.Playfield.PlayfieldArgs.MinX, this.Playfield.PlayfieldArgs.MaxX + 1);
            int y = this.random.Next(this.Playfield.PlayfieldArgs.MinY, this.Playfield.PlayfieldArgs.MaxY + 1);

            return new Snake(x, y, 100);
        }
    }
}
