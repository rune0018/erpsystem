using System;
namespace ERPsystem
{

    //todo
    //1. (bug)input kan ikke være kommatal

    class Program
    {
        static void Main(string[] args)
        {
            Logger.Info("Programmet er startet");
            Console.SetWindowSize(150, 20);

            Inventory.Items = Database.GetItems();
            Inventory.Orders = Database.GetOrders();
            Inventory.OrderLines = Database.GetOrderLines();
            Console.WriteLine(Inventory.Items[0].SalePrice);
            
            if (test.sqlConnection())
            {
                MainScreen.Mainmenu();
            }
            
        }
    }
}
