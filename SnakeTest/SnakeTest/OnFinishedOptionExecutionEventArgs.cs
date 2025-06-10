using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class OnFinishedOptionExecutionEventArgs
    {
        public OnFinishedOptionExecutionEventArgs(bool isExitRequested)
        {
            this.ExitRequested = isExitRequested;
        }

        public bool ExitRequested
        {
            get;
            set;
        }
    }
}
