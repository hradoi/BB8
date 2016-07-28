using StorageYard.Data;
using StorageYard.Enum;
using StorageYard.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OrderManager.Instance.CreateOrder("Alex", true, true);

            }
            catch (Exception e)
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
