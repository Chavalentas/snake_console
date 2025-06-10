using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class OnPressedKeyEventArgs
    {
        public OnPressedKeyEventArgs(ConsoleKeyInfo keyInformation)
        {
            this.KeyInformation = keyInformation;
        }

        public ConsoleKeyInfo KeyInformation
        {
            get;
            private set;
        }
    }
}
