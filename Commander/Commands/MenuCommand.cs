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
        private string target = null;

        public CommandResult execute(Order context)
        {
            if (target == null)
            {
                CommandResult res = new CommandResult();
                res.AddResult("From where?");
                return res;
            }
            Menu menu = OrderManager.Instance.SelectMenus().Where(one => one.Name.Contains(target)).FirstOrDefault();
            CommandResult result = new CommandResult();
            result.AddResult(target + "menu :");
            foreach(Item i in menu.Items.ToList())
            {
                result.AddResult(i.Name);
            }
            return result;
        }

        public void SetTarget(string value)
        {
            target = value;
        }
    }
}
