using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public abstract class MenuOption
    {
        private string optionText;

        private int x;

        private int y;

        public MenuOption(string text, int x, int y)
        {
            this.OptionText = text;
            this.X = x;
            this.Y = y;
        }

        public event EventHandler<OnFinishedOptionExecutionEventArgs> OnFinishedExecution;

        public int X
        {
            get
            {
                return this.x;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the x coordinate cannot be less than 0!");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the y coordinate cannot be less than 0!");
                }

                this.y = value;
            }
        }

        public string OptionText
        {
            get
            {
                return this.optionText;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value of the option text cannot be null!");
                }

                this.optionText = value;
            }
        }

        public abstract void Perform();

        protected virtual void FireOnFinishedExecution(OnFinishedOptionExecutionEventArgs args)
        {
            this.OnFinishedExecution?.Invoke(this, args);
        }
    }
}
