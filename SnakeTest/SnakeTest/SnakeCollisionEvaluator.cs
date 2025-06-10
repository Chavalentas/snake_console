using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class SnakeCollisionEvaluator
    {
        private Snake snake;

        private List<GameObject> gameObjects;

        private Playfield playfield;

        private Random random;
        public SnakeCollisionEvaluator(Snake snake, List<GameObject> gameObjects, Playfield playfield, Random random)
        { 
            this.Snake = snake;
            this.GameObjects = gameObjects;
            this.Playfield = playfield;
            this.random = random ?? throw new ArgumentNullException("The value of the random generator cannot be null!");
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

        public void Evaluate()
        {
             this.EvaluatePlayfieldCollision();
             this.EvaluateSelfCollision();
             this.EvaluateGameObjectsCollision();
        }

        protected virtual void FireOnRemovedGameObject(OnRemovedGameObjectEventArgs args)
        {
            this.OnRemovedGameObject?.Invoke(this, args);
        }

        private void EvaluatePlayfieldCollision()
        {
            if (this.Snake.Segments[0].X == this.Playfield.PlayfieldArgs.MinX - 1)
            {
                throw new FatalCollisionException("Collision with the left side of the playfield occurred!");
            }

            if (this.Snake.Segments[0].X == this.Playfield.PlayfieldArgs.MaxX + 1)
            {
                throw new FatalCollisionException("Collision with the right side of the playfield occurred!");
            }

            if (this.Snake.Segments[0].Y == this.Playfield.PlayfieldArgs.MinY - 1)
            {
                throw new FatalCollisionException("Collision with the upper side of the playfield occurred!");
            }

            if (this.Snake.Segments[0].Y == this.Playfield.PlayfieldArgs.MaxY + 1)
            {
                throw new FatalCollisionException("Collision with the bottom side of the playfield occurred!");
            }
        }

        private void EvaluateSelfCollision()
        {
            if (this.Snake.Segments.Count == 1)
            {
                return;
            }

            for (int index = 1; index < this.Snake.Segments.Count; index++)
            {
                if (this.Snake.Segments[0].X == this.Snake.Segments[index].X && this.Snake.Segments[0].Y == this.Snake.Segments[index].Y)
                {
                    throw new FatalCollisionException("The collision with the body occurred!");
                }
            }
        }

        private void EvaluateGameObjectsCollision()
        {
            foreach (var gameObject in this.GameObjects.ToList())
            {
                EvaluateSnakeGameObjectCollisionVisitor collisionVisitor = new EvaluateSnakeGameObjectCollisionVisitor(this.Snake, this.random);
                collisionVisitor.OnRemovedGameObject += this.RemovedGameObjectCallback;
                gameObject.AcceptVisitor(collisionVisitor);
            }
        }

        private void RemovedGameObjectCallback(object sender, OnRemovedGameObjectEventArgs args)
        {
            this.FireOnRemovedGameObject(args);
        }
    }
}
