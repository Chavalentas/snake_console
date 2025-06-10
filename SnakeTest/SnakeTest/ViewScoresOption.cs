using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeTest
{
    public class ViewScoresOption : MenuOption
    {
        private GameScoreTable gameScoreTable;

        public ViewScoresOption(string text, int x, int y, GameScoreTable gameScoreTable) : base(text, x, y)
        {
            this.GameScoreTable = gameScoreTable;
        }

        public GameScoreTable GameScoreTable
        {
            get
            {
                return this.gameScoreTable;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the game score table cannot be null!");
                }

                this.gameScoreTable = value;
            }
        }

        public override void Perform()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            List<GameScore> scores = this.GameScoreTable.GameScores;

            if (scores.Count == 0)
            {
                Console.WriteLine("No previous scores available!");
            }
            else
            {
                this.Print(scores);
            } 

            Console.ReadLine();

            this.FireOnFinishedExecution(new OnFinishedOptionExecutionEventArgs(false));
        }

        private void Print(List<GameScore> scores)
        {

            foreach (var score in scores)
            {
                Console.Write(score.Timestamp);
                Console.Write(" ");
                Console.WriteLine(score.PointCount);
                Console.WriteLine();
            }
        }
    }
}