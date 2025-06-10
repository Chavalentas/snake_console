using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class OnUpdatedStepCounterEventArgs
    {
        private int currentValue;

        public OnUpdatedStepCounterEventArgs(int currentValue)
        {
            this.CurrentValue = currentValue;
        }

        public int CurrentValue
        {
            get
            {
                return this.currentValue;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the step counter cannot be less than 0!");
                }

                this.currentValue = value;
            }
        }
    }
}
