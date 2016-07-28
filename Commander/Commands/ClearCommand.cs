using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageYard.Data;
using Commander.Interfaces;

namespace Commander.Commands
{
    public class ClearCommand : Command
    {
        private List<string> Parameters = new List<string>();

        public CommandResult execute(Order context)
        {
            context.Items.Clear();
            return new CommandResult("Order cleared.");
        }

        public void AddParameter(string value)
        {
            Parameters.Add(value);
        }
    }
}
