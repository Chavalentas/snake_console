using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class SerializationErrorException : Exception
    {
        public SerializationErrorException(string message) : base(message)
        {
        }
    }
}
