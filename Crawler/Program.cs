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
                Store s1 = new Sector();
                Store s2 = new Yellow();
                s1.UpdateDB();
                s2.UpdateDB();
            }
            finally
            {
                OrderManager.Instance.Dispose();
            }
        }
    }
}
