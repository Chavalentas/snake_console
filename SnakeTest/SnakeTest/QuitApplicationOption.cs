using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class QuitApplicationOption : MenuOption
    {
        public QuitApplicationOption(string text, int x, int y) : base(text, x, y)
        {
        }
        
        public override void Perform()
        {
            this.FireOnFinishedExecution(new OnFinishedOptionExecutionEventArgs(true));
        }
    } 
}
