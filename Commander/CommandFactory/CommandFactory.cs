using Commander.Interfaces;
using Commander.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commander.Exceptions;

namespace Commander.CommandFactory
{
    class CommandFactory
    {
        public static Command BuildCommand(string commandString)
        {
            if (string.IsNullOrEmpty(commandString))
                throw new EmptyStringException();
            string[] tokens = commandString.Split(' ');
            switch (tokens[0])
            {
                case :
            }

        }
    }
}
