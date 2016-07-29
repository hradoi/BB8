using Crawler.Interface;
using Crawler.Stores;
using StorageYard.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Store c = new Sector();
                c.UpdateDB();
            }
            finally
            {
                OrderManager.Instance.Dispose();
            }
        }
    }
}
