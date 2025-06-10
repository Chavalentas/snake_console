using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class OnChosenOptionEventArgs
    {
        private int optionIndex;

        public OnChosenOptionEventArgs(int optionIndex)
        {
            this.OptionIndex = optionIndex;
        }

        public int OptionIndex
        {
            get
            {
                return this.optionIndex;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the previous option index cannot be less than 0!");
                }

                this.optionIndex = value;
            }
        }
    }
}
