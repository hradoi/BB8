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
    public class MenuCommand : Command
    {
        private List<string> Parameters = new List<string>();

        public CommandResult execute(Order context)
        {
            Menu menu = OrderManager.Instance.SelectMenus().Where(one => one.Name.Contains(Parameters.First())).FirstOrDefault();
            string result = "";
            foreach(Item i in menu.Items.ToList())
            {
                result = result + "\n" + i.Name;
            }
            return new CommandResult(Parameters.First() + " menu :" + result);
        }

        public void AddParameter(string value)
        {
            Parameters.Add(value);
        }
    }
}
