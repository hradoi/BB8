using Crawler.Interface;
using Crawler.Stores;
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
            Store c = new Sector();
            c.UpdateDB();
        }
    }
}
