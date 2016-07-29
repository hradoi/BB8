using Crawler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageYard.Manager;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using StorageYard.Data;

namespace Crawler.Stores
{
    public class Sector : Store
    {
        public void UpdateDB()
        {
<<<<<<< HEAD
            Menu p = OrderManager.Instance.Create("Sector Gurmand", true, true);
=======
            Menu p = OrderManager.Instance.Create("Sector", true, true);
>>>>>>> refs/remotes/origin/yellowcrawler

            List<string> titles = new List<string>();
            List<string> descriptions = new List<string>();
            List<string> prices = new List<string>();

            WebClient web = new WebClient();
            string html = web.DownloadString("https://www.sectorgurmand.ro");
            MatchCollection m1 = Regex.Matches(html, @"<h3><a" + "(.+?)" + "</a>", RegexOptions.Singleline);
            foreach (Match m in m1)
            {

                string anything = m.Groups[1].Value;

                int index = anything.IndexOf(">");
                string mystring = "";
                mystring = anything.Substring(index + 1, anything.Length - (index + 1));
                titles.Add(mystring);

            }
            MatchCollection m2 = Regex.Matches(html, @"<p class=" + "\"max_lines" + "\"" + ">" + "(.+?)" + "</p>", RegexOptions.Singleline);

            foreach (Match m in m2)
            {

                string anything = m.Groups[1].Value;
                descriptions.Add(anything);
            }

            MatchCollection m3 = Regex.Matches(html, @"<div class=" + "\"" + "meta-price pull-left" + "\"" + ">" + "(.+?)" + "</div>", RegexOptions.Singleline);

            foreach (Match m in m3)
            {

                string anything = m.Groups[1].Value;
                anything = anything.Trim();
                anything = anything.Split(' ').First();
                prices.Add(anything);
            }
            for (int e = 0; e < titles.Count; e++)
            {
                Item i = OrderManager.Instance.Create(titles.ElementAt(e), Convert.ToDouble(prices.ElementAt(e)), descriptions.ElementAt(e), p);
            }

            OrderManager.Instance.Save();
        }
    }
}
