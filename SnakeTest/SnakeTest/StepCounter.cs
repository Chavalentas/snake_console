using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class StepCounter
    {
        private int currentValue;

        public event EventHandler<OnUpdatedStepCounterEventArgs> OnUpdatedStepCounter;

        public int CurrentValue
        {
            get
            {
                return this.currentValue;
            }

             set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the step counter cannot be less than 0!");
                }

                this.currentValue = value;
                this.FireOnUpdatedStepCounter(new OnUpdatedStepCounterEventArgs(value));
            }
        }

        public void SetTo(int value)
        {
            this.CurrentValue = value;
        }

        protected virtual void FireOnUpdatedStepCounter(OnUpdatedStepCounterEventArgs args)
        {
            this.OnUpdatedStepCounter?.Invoke(this, args);
        }
    }
}
