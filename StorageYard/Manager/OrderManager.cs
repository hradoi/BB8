using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageYard.FContext;
using StorageYard.Data;
using StorageYard.Repo;

namespace StorageYard.Manager
{
    public class OrderManager : IDisposable
    {
        private static volatile OrderManager instance;
        private static object syncRoot = new Object();
        private GRepo<Context> Repo;
        private OrderManager() {
            Repo = new GRepo<Context>();
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public static void Close()
        {
            instance.Dispose();
            instance = null;
        }

        public static OrderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new OrderManager();
                    }
                }

                return instance;
            }
        }

        public Order CreateOrder(string name, bool insert = false, bool save = false)
        {
            Order o = Repo.Context.Orders.Find(name);
            if (o == null)
            {
                o = Repo.Context.Orders.Create();
                o.OrderId = name;
                if (insert)
                {
                    return Repo.Insert<Order>(o, save);
                }
            }
            return o;
        }
        public Menu Create(string name, bool insert = false, bool save = false)
        {
            Menu m = Repo.Context.Menus.Create();
            m.Name = name;
            if (insert)
            {
                return Repo.Insert<Menu>(m, save);
            }
            return m;
        }
        public Item Create(string name, double price, string description = null, Menu menu = null, bool save = false)
        {
            Item i = Repo.Context.Items.Create();
            i.Name = name;
            i.Price = price;
            i.Description = description;
            if (menu != null)
            {
                Insert(menu, i, save);
            }
            return i;
        }

        public Order Associate(Item item, Order order, bool save = true)
        {
            order.Items.Add(item);
            return Repo.Context.Entry(order).Entity;
        }

        public Menu Insert(Menu menu, bool save = true)
        {
            return Repo.Insert<Menu>(menu, save);
        }
        public Item Insert(string menu, Item item, bool save = true)
        {
            foreach(Menu m in Repo.Select<Menu>().ToList())
            {
                if(m.Name == menu)
                {
                    m.Items.Add(item);
                    if (save)
                    {
                        Repo.Save();
                    }
                    return Repo.Context.Entry(item).Entity;
                }
            }
            return null;
        }
        public Item Insert(Menu menu, Item item, bool save = true)
        {
            if(menu.Items == null)
            {
                Repo.Save();
            }
            menu.Items.Add(item);
            if (save)
            {
                Repo.Save();
            }
            return Repo.Context.Entry(item).Entity;
        }
        public Order Insert(Order order, bool save = true)
        {
            return Repo.Insert<Order>(order, save);
        }


        public Menu Update(Menu menu, bool save = true)
        {
             return Repo.Update<Menu>(menu, save);
        }
        public Item Update(Item item, bool save = true)
        {
            return Repo.Update<Item>(item, save);
        }
        public Order Update(Order order, bool save = true)
        {
            return Repo.Update<Order>(order, save);
        }


        public Menu Delete(Menu menu, bool save = true)
        {
            return Repo.Delete<Menu>(menu, save);
        }
        public Item Delete(Item item, bool save = true)
        {
            return Repo.Delete<Item>(item, save);
        }
        public Order Delete(Order order, bool save = true)
        {
            return Repo.Delete<Order>(order, save);
        }

        public IQueryable<Menu> SelectMenus()
        {
            return Repo.Select<Menu>();
        }
        public IQueryable<Item> SelectItems()
        {
            return Repo.Select<Item>();
        }
        public IQueryable<Order> SelectOrders()
        {
            return Repo.Select<Order>();
        }

        public void EmptyDB()
        {
            foreach (Menu m in Repo.Context.Menus)
            {
                Repo.Delete<Menu>(m, false);
            }
            foreach (Item i in Repo.Context.Items)
            {
                Repo.Delete<Item>(i, false);
            }
            foreach (Order o in Repo.Context.Orders)
            {
                Repo.Delete<Order>(o, false);
            }
            Repo.Save();
        }


        public int Save()
        {
            return Repo.Save();
        }
    }
}
