using Crawler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageYard.Manager;
using StorageYard.Data;

namespace Crawler.Stores
{
    public class Yellow : Store
    {
        public void UpdateDB()
        {
            Menu m = OrderManager.Instance.Create("Yellow", true, true);
            Item i = OrderManager.Instance.Create("supa", 12.7, "test",m,true);


            OrderManager.Instance.Save();
        }
    }
}
