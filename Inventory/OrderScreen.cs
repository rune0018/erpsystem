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
                UI.write("Tryk på 1 for at tlføje en ordrelinje til en ordre\n");
                UI.write("Tryk på 2 for at modtage alle vare\n");
                UI.write("Tryk på 3 for at se alle ordrelinjer\n");
                UI.write("Tryk på 4 for at komme ud af menu'en\n");
                int input = Input.GetNumberFromUser("");
                Console.Clear();
                switch (input)
                {
                    case 1:
                        try
                        {
                            AddOrderLine(Inventory.Items[InventoryScreen.FindIndexItem(Input.GetNumberFromUser("Varenummer"))],Inventory.Orders[FindindexOrders(Input.GetNumberFromUser("OrderID"))]);
                        }
                        catch(ArgumentOutOfRangeException e)
                        {
                            UI.write("en af de 2 tal findes ikke\n");
                            Logger.Error(e.Message);
                            Logger.Error(e.StackTrace);
                        }
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
        public static void AddOrderLine(Item item,Order order)
        {
            OrderLine NewOrderLine = new();
            NewOrderLine.OrderID = order.ID;
            NewOrderLine.ItemID = item.ID;
            NewOrderLine.Amount = Input.GetNumberFromUser("Hvor mange vil du have bestilt");
            Inventory.OrderLines.Add(NewOrderLine);
            Database.Insert(NewOrderLine);
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
        public static int FindindexOrders(int search)
        {
            for (int indeks = 0; indeks < Inventory.Orders.Count; indeks++)
            {
                if (Inventory.Orders[indeks].ID == search)
                {
                    return indeks;
                }
            }
            return -1;
        }
    }
}
