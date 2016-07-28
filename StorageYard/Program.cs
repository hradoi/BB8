using StorageYard.Data;
using StorageYard.Enum;
using StorageYard.FContext;
using StorageYard.Manager;
using StorageYard.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageYard
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu menu = OrderManager.Instance.Create(Source.Yellow, true);
                Item item = OrderManager.Instance.Create("Pizza", 0.78, "Nu mai e.", menu, true);
                foreach (Menu m in OrderManager.Instance.SelectMenus().ToList())
                {
                    if (m.Items != null)
                    {
                        foreach (Item i in m.Items)
                        {
                            Console.WriteLine(i.MenuId);
                        }

                    }
                    Console.WriteLine(m.MenuId);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                OrderManager.Instance.Dispose();
            }
            Console.ReadKey();
        }
    }
}
