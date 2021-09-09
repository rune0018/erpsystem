using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem
{
    class OrderScreen
    {
        /// <summary>
        /// Goes to the order menu
        /// </summary>
        public static void OrderMenu()
        {
            bool repeat = true;
            do
            {
                UI.write("Tryk på 1 for at tlføje en ordre\n");
                UI.write("Tryk på 2 for at modtage alle vare\n");
                UI.write("Tryk på 3 for at se ordre listen\n");
                UI.write("Tryk på 4 for at komme ud af menu'en\n");
                int input = Input.GetNumberFromUser("");
                Console.Clear();
                switch (input)
                {
                    case 1:
                        AddOrder(Inventory.Items[InventoryScreen.FindIndexInventory(Input.GetNumberFromUser("Varenummer"))]);
                        break;
                    case 2:
                        Inventory.ReciveOrder();
                        break;
                    case 3:
                        ShowOrders(Inventory.Orders);
                        break;
                    case 4:
                        repeat = false;
                        break;
                    default:
                        UI.write("Forkert input");
                        break;
                }
                    
            } while (repeat);
        }
        /// <summary>
        /// Adds an order to the orders list using the item
        /// </summary>
        /// <param name="item"></param>
        public static void AddOrder(Item item)
        {
            Order NewOrder = new();
            NewOrder.Itemname = item.name;
            NewOrder.Itemlokation = item.Invetoryplace;
            NewOrder.Amount = Input.GetNumberFromUser("Hvor mange flere vil du have bestilt");
            Inventory.Orders.Add(NewOrder);
        }
        public static void ShowOrders(List<Order> orders)
        {
            UI.write("Name");
            Console.CursorLeft = 20;
            UI.write("Lokation");
            Console.CursorLeft = 40;
            UI.write("Amount\n");
            int i = 0;
            while (i < Console.WindowWidth - 1)
            {
                i++;
                UI.write("=");
            }
            UI.write("\n");
            foreach(Order order in orders)
            {
                UI.write(order.Itemname);
                Console.CursorLeft = 20;
                UI.write(order.Itemlokation.ToString());
                Console.CursorLeft = 40;
                UI.write(order.Amount.ToString());
                UI.write("\n");
            }
        }
    }
}
