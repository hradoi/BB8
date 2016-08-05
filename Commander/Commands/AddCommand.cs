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
        private List<string> items = new List<string>();
        private string source = null;

        public CommandResult execute(Order context)
        {
            CommandResult result = new CommandResult();
            
            if(items.Count == 0)
            {
                result.AddResult("What items do you need?");
            }

            if(source == null)
            {
                foreach(string str in items)
                {
                    var it = OrderManager.Instance.SelectItems().Where(i => i.Name.Contains(str)).FirstOrDefault();
                    if (it != null)
                    {
                        context.Items.Add(it);
                        result.AddResult(it.Name + " was added to your order.");
                    }else
                    {
                        result.AddResult("Can't find: " + str);
                    }
                }
            }
            else
            {
                foreach (string str in items)
                {
                    var it = OrderManager.Instance.SelectItems().Where(i => i.Name.Contains(str)&&i.Menu.Name.Contains(source)).FirstOrDefault();
                    if (it != null)
                    {
                        context.Items.Add(it);
                        result.AddResult(it.Name +" from " +source+ " was added to your order.");
                    }
                    else
                    {
                        result.AddResult("Can't find: " + str + "from "+source);
                    }
                }
            }
            OrderManager.Instance.Save();
            return result;
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void SetSource(string source)
        {
            this.source = source;
        }
    }
}
