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
        private string target;

        public CommandResult execute(Order context)
        {
            Menu menu = OrderManager.Instance.SelectMenus().Where(one => one.Name.Contains(target)).FirstOrDefault();
            string result = "";
            foreach(Item i in menu.Items.ToList())
            {
                result = result + "\n\n" + i.Name;
            }
            return new CommandResult(target + " menu :" + result);
        }

        public void AddParameter(string value)
        {
            target = value;
        }
    }
}
