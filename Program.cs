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

            Inventory.Items = Database.GetItems();
            Inventory.Orders = Database.GetOrders();
            Console.WriteLine(Inventory.Items[0].SalePrice);
            Database.Insert(Inventory.Items[0]);
            if (test.sqlConnection())
            {
                Inventory.CreateItem(1, "hej", 2, 0.2, 0.5, 6);
                Inventory.CreateItem(2, "kage", 3, 10.2, 8.5, 123);
                MainScreen.Mainmenu();
            }
            
        }
    }
}
