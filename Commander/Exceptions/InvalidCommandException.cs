using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Exceptions
{
    class InvalidCommandException : Exception
    {
        public InvalidCommandException(string commandString) : base(string.Format("I don't understand what you mean by:\"{0}\"", commandString))
        {

        }
    }
}
