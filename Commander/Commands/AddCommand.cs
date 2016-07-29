using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageYard.Data;
using Commander.Interfaces;
using StorageYard.Manager;

namespace Commander.Commands
{
    public class AddCommand : Command
    {
        private List<string> Parameters = new List<string>();

        public CommandResult execute(Order context)
        {
            if(Parameters.Count != 2)
            {
                return null;
            }
            
            List<string> invalid = new List<string>();

            var items = from i in OrderManager.Instance.SelectItems()
                        where i.Menu.Name.Contains(Parameters.First()) && i.Name.Contains(Parameters.Last())
                        select i;

            if(items.Count() == 0)
            {
                return new CommandResult("Can't find anything with that name.");
            }
            if(items.Count() > 1)
            {
                string result = "";
                foreach(Item i in items.ToList())
                {
                    result = result + "\n" + i.Name;
                }
                return new CommandResult("I found: " + result);
            }
            context.Items.Add(items.FirstOrDefault());

            return new CommandResult(items.FirstOrDefault() + "was added to your order.");
        }

        public void AddParameter(string value)
        {
            Parameters.Add(value);
        }
    }
}
