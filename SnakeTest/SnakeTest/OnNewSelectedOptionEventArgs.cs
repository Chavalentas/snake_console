using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeTest
{
    public class OnNewSelectedOptionEventArgs
    {
        private int previousOptionIndex;

        private int currentOptionIndex;

        public OnNewSelectedOptionEventArgs(int previousOptionIndex, int currentOptionIndex)
        {
            this.PreviousOptionIndex = previousOptionIndex;
            this.CurrentOptionIndex = currentOptionIndex;
        }

        public int PreviousOptionIndex
        {
            get
            {
                return this.previousOptionIndex;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the previous option index cannot be less than 0!");
                }

                this.previousOptionIndex = value;
            }
        }

        public int CurrentOptionIndex
        {
            get
            {
                return this.currentOptionIndex;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the current option index cannot be less than 0!");
                }

                this.currentOptionIndex = value;
            }
        }
    }
}