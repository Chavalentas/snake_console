using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class OnFinishedGameEventArgs
    {
        private GameScore gameScore;

        public OnFinishedGameEventArgs(GameScore gameScore)
        {
            this.GameScore = gameScore;
        }

        public GameScore GameScore
        {
            get
            {
                return this.gameScore;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the game score cannot be null!");
                }

                this.gameScore = value;
            }
        }
    }
}
