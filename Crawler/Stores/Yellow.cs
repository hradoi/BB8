using Crawler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageYard.Manager;
using StorageYard.Data;
using System.Text.RegularExpressions;
using Crawler.Models;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Crawler.Stores
{
    public class Yellow : Store
    {
        public void UpdateDB()
        {
            
            Menu p = OrderManager.Instance.Create("yellow", true, true);
            
            WebRequest request = WebRequest.Create("https://www.yellow.menu/yellowserver/api/core/menus/activeMenus?ReturnDetails=false");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            incomingJson IncomingMenu = JsonConvert.DeserializeObject<incomingJson>(responseFromServer);
            foreach (Dish d in IncomingMenu.Items[0].Dishes)
            {
                OutputMenu fi = new OutputMenu()
                {
                    Name = d.Title,
                    Description = d.Description,
                    Price = d.Price.Value,               
                };
                Item i = OrderManager.Instance.Create(fi.Name, fi.Price, fi.Description, p, true);
            }
         
        }
    }
}
