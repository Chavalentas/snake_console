using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class DeserializationErrorException : Exception
    {
        public DeserializationErrorException(string message) : base(message)
        {
        }
    }
}
