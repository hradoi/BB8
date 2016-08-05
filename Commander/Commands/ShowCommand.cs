using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageYard.Data;
using Commander.Interfaces;

namespace Commander.Commands
{
    public class ShowCommand : Command
    {
        public CommandResult execute(Order context)
        {
            CommandResult result = new CommandResult();
            result.AddResult("You have: ");

            bool found = false;
            foreach (Item i in context.Items.ToList())
            {
                result.AddResult(i.Name);
                found = true;
            }

            if (!found)
            {
                result = new CommandResult();
                result.AddResult("Your order is empty.");
            }

            return result;
        }
    }
}
