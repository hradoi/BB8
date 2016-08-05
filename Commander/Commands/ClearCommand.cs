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
    public class ClearCommand : Command
    {
        private List<string> items = new List<string>();

        public CommandResult execute(Order context)
        {
            CommandResult result = new CommandResult();
            if(items.Count == 0)
            {
                context.Items.Clear();
                OrderManager.Instance.Save();
                result.AddResult("Order cleared.");
                return result;
            } else
            {
                List<string> deletedItems = new List<string>();
                foreach(string str in items)
                {
                    var it = context.Items.Where
                        (i => i.Name.Contains(str)).FirstOrDefault();
                    if (it != null)
                    {
                        deletedItems.Add(it.Name);
                        context.Items.Remove(it);
                    }
                }
                OrderManager.Instance.Save();
                
                foreach(string it in deletedItems)
                {
                    result.AddResult(it);
                }
                result.AddResult("Items removed.");
                return result;
            }
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }
    }
}
