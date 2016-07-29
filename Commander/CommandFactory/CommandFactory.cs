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
    public class CommandFactory
    {
        public static Command BuildCommand(string commandString)
        {
            if (string.IsNullOrEmpty(commandString))
                throw new EmptyStringException();
            string[] tokens = commandString.Split(' ');

            Command c = null;

            switch (tokens[0])
            {
                case "add":
                    {
                        c = new AddCommand();
                        c.AddParameter(tokens[1]);
                        c.AddParameter(tokens[2]);
                        break;
                    }
                case "show":
                    {
                        c = new ShowCommand();
                        break;
                    }
                case "clear":
                    {
                        c = new ClearCommand();
                        break;
                    }
                case "list":
                    {
                        c = new MenuCommand();
                        c.AddParameter(tokens[1]);
                        break;
                    }
                default:
                    throw new InvalidCommandException(commandString);
            }
            return c;
        }
    }
}
