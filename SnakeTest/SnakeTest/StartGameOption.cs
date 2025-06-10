using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeTest
{
    public class StartGameOption : MenuOption
    {
        public StartGameOption(string text, int x, int y) : base(text, x, y)
        {
        }

        public event EventHandler<OnFinishedGameEventArgs> OnFinishedGame;

        public override void Perform()
        {
            Console.Clear();
            Game game = new Game();
            game.OnFinishedGame += this.FinishedGameCallback;
            game.Start();
        }

        protected virtual void FireOnFinishedGame(OnFinishedGameEventArgs args)
        {
            this.OnFinishedGame?.Invoke(this, args);
        }

        private void FinishedGameCallback(object sender, OnFinishedGameEventArgs args)
        {
            this.FireOnFinishedGame(args);
            this.FireOnFinishedExecution(new OnFinishedOptionExecutionEventArgs(false));
        }
    }
}