using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class FatalCollisionException : Exception
    {
        public FatalCollisionException(string message) : base(message)
        {
        }
    }
}
