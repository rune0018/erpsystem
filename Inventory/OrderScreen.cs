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
                        AddOrderLine(Inventory.Items[InventoryScreen.FindIndexInventory(Input.GetNumberFromUser("Varenummer"))]);
                        break;
                    case 2:
                        Inventory.ReciveOrder();
                        break;
                    case 3:
                        ShowOrderLines(Inventory.OrderLines);
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
        public static void AddOrderLine(Item item)
        {
            OrderLine NewOrder = new();
            NewOrder.OrderID = Input.GetNumberFromUser("OrdreID");
            NewOrder.ItemID = item.ID;
            NewOrder.Amount = Input.GetNumberFromUser("Hvor mange vil du have bestilt");
            Inventory.OrderLines.Add(NewOrder);
        }
        public static void ShowOrderLines(List<OrderLine> orderlins)
        {
            UI.write("ID");
            Console.CursorLeft = 20;
            UI.write("OrderID");
            Console.CursorLeft = 40;
            UI.write("ItemID");
            Console.CursorLeft = 60;
            UI.write("Amount\n");
            int i = 0;
            while (i < Console.WindowWidth - 1)
            {
                i++;
                UI.write("=");
            }
            UI.write("\n");
            foreach(OrderLine orderline in orderlins)
            {
                UI.write(orderline.ID.ToString());
                Console.CursorLeft = 20;
                UI.write(orderline.OrderID.ToString());
                Console.CursorLeft = 40;
                UI.write(orderline.ItemID.ToString());
                Console.CursorLeft = 60;
                UI.write(orderline.Amount.ToString());
                UI.write("\n");
            }
        }
    }
}
