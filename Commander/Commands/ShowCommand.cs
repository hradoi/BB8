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
        private List<string> Parameters = new List<string>();

        public CommandResult execute(Order context)
        {
            string result = "";

            foreach (Item i in context.Items.ToList())
            {
                result = result + "\n" + i.Name;
            }

            if (string.IsNullOrEmpty(result))
            {
                result = "Your order is empty.";
            }

            return new CommandResult(result);
        }

        public void AddParameter(string value)
        {
            Parameters.Add(value);
        }
    }
}
