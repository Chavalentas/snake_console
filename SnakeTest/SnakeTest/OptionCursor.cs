using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeTest
{
    public class OptionCursor
    {
        private int optionIndex;

        private int maxIndex;

        public OptionCursor(int startIndex, int maxIndex)
        {
            this.OptionIndex = startIndex;
            this.maxIndex = maxIndex >= 0 ? this.maxIndex = maxIndex : throw new ArgumentOutOfRangeException("The value of the maximal index cannot be less than 0!");
        }

        public event EventHandler<OnNewSelectedOptionEventArgs> OnNewSelectedOption;

        public event EventHandler<OnChosenOptionEventArgs> OnChosenOption;

        public int OptionIndex
        {
            get
            {
                return this.optionIndex;
            }

             set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > this.maxIndex)
                {
                    value = this.maxIndex;
                }

                if (value != this.optionIndex)
                {
                    this.FireOnNewSelectedOption(new OnNewSelectedOptionEventArgs(this.optionIndex, value));
                }

                this.optionIndex = value;
            }
        }

        public void PressedKeyCallback(object sender, OnPressedKeyEventArgs args)
        {
            switch (args.KeyInformation.Key)
            {
                case ConsoleKey.UpArrow:
                    this.OptionIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    this.OptionIndex++;
                    break;
                case ConsoleKey.Enter:
                    this.FireOnChosenOption(new OnChosenOptionEventArgs(this.OptionIndex));
                    break;
            }
        }

        protected virtual void FireOnNewSelectedOption(OnNewSelectedOptionEventArgs args)
        {
            this.OnNewSelectedOption?.Invoke(this, args);
        }

        protected virtual void FireOnChosenOption(OnChosenOptionEventArgs args)
        {
            this.OnChosenOption?.Invoke(this, args);
        }
    }
}