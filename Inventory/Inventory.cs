using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;

namespace ERPsystem
{
    public class Inventory
    {
        

        public static List<Item> Items = new List<Item>();
        public static List<Order> Orders = new List<Order>();
        public static List<OrderLine> OrderLines = new List<OrderLine>();

        static Inventory()
        {
            Items = Database.GetItems();
        }
        //opretter en vare og definere alt i Vare classen
        public static void CreateItem(int varenummer, string name, int antal, double salgspris, double indkøbspris, int lagerplads)
        {
            Item newItem = new Item();
            newItem.Itemnumber = varenummer;
            newItem.name = name;
            newItem.amount = antal;
            newItem.SalePrice = salgspris;
            newItem.PurchasePrice = indkøbspris;
            newItem.Invetoryplace = lagerplads;
            Items.Add(newItem);
        }
        

        //søger efter varenummer der matcher søgning
        public static List<Item> SerchInventory(int serach)
        {
            IEnumerable<Item> quere =
                from vare in Items
                where find_str(vare.Itemnumber.ToString(), serach.ToString().Length) == serach.ToString()
                select (vare);
            List<Item> result = new();
            foreach (Item vare in quere)
            {
                result.Add(vare);
            }
            return result;
        }
        private static string find_str(string input, int length)
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output = output + input[i];
            }
            return output;
        }
        /// <summary>
        /// Takes all orders and adds the amounts int each order to the inventory 
        /// </summary>
        public static void ReciveOrder()
        {

            foreach (Item item in Items)
            {
                for(int i = 0; i < OrderLines.Count; i++)
                {
                    if(item.ID == OrderLines[i].ItemID)
                    {
                        item.amount -= OrderLines[i].Amount;
                        Database.Delete(OrderLines[i]);
                        break;
                    }
                }
                Database.Update(item);
            }
        }
    }

}
