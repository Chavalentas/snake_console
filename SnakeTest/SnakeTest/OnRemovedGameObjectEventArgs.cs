using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class OnRemovedGameObjectEventArgs
    {
        private GameObject gameObject;

        public OnRemovedGameObjectEventArgs(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }

        public GameObject GameObject
        {
            get
            {
                return this.gameObject;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the game object cannot be null!");
                }

                this.gameObject = value;
            }
        }
    }
}
