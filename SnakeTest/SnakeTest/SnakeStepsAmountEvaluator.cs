using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class SnakeStepsAmountEvaluator
    {
        private Random random;

        private GameObjectCreator gameObjectCreator;

        private List<GameObject> gameObjects;

        private int randomNumber;

        private StepCounter stepCounter;

        public SnakeStepsAmountEvaluator(StepCounter stepCounter, Random random, GameObjectCreator gameObjectCreator, List<GameObject> gameObjects)
        {
            this.random = random ?? throw new ArgumentNullException("The value of the random generator cannot be null!");
            this.randomNumber = this.random.Next(1, 101);
            this.stepCounter = stepCounter ?? throw new ArgumentNullException("The value of the step counter cannot be null!");
            this.stepCounter.OnUpdatedStepCounter += this.UpdatedStepCounterCallback;
            this.gameObjectCreator = gameObjectCreator ?? throw new ArgumentNullException("The value of the game object creator cannot be null!");
            this.GameObjects = gameObjects ?? throw new ArgumentNullException("The value of the game objects cannot be null!");
        }

        public event EventHandler<OnNewGameObjectEventArgs> OnNewGameObject;

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

        public void UpdatedStepCounterCallback(object sender, OnUpdatedStepCounterEventArgs args)
        {
            if (args.CurrentValue == this.randomNumber)
            {
                this.randomNumber = this.random.Next(1, 101);
                GameObject newGameObject = this.gameObjectCreator.Create();
                this.GameObjects.Add(newGameObject);
                this.FireOnNewGameObject(new OnNewGameObjectEventArgs(newGameObject));
                this.stepCounter.SetTo(0);
            }
        }

        protected virtual void FireOnNewGameObject(OnNewGameObjectEventArgs args)
        {
            this.OnNewGameObject?.Invoke(this, args);
        }
    }
}
