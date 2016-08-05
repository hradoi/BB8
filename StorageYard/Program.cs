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
            using (var ctx = new Context())
            {
                ctx.Database.Delete();
            }
        }
    }
}
