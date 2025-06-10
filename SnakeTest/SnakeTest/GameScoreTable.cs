using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameScoreTable
    {
        private List<GameScore> gameScores;

        public GameScoreTable()
        {
            this.GameScores = new List<GameScore>();
        }

        public List<GameScore> GameScores
        {
            get
            {
                return this.gameScores;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the game scores cannot be null!");
                }

                this.gameScores = value;
            }
        }
    }
}
