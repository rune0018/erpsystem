using System;
using System.Collections.Generic;

namespace ERPsystem
{
    static class InventoryScreen
    {
        public static void InventoryMenu(List<Item> items)
        {
            bool Repeat = true;
            do
            {
                UI.write("Tryk på 1 for at oprette en vare\n");
                UI.write("Tryk på 2 for at rette en vare\n");
                UI.write("Tryk på 3 for at søge efter en vare\n");
                UI.write("Tryk på 4 for at se listen af vare\n");
                UI.write("Tryk på 5 for at fjerne fra lageret\n");
                UI.write("Tryk på 6 for at gå ind i varebestilling\n");
                UI.write("Tryk på 7 for at afslutte pc'en\n");
                int input = Input.GetNumberFromUser("");
                Console.Clear();
                switch (input)
                {
                    case 1:
                        CreateItem();
                        break;
                    case 2:
                        Rediger_vare(Inventory.Items[FindIndexItem(Input.GetNumberFromUser("Varenummer"))]);
                        break;
                    case 3:
                        Inventorylist(Inventory.SerchInventory(Input.GetNumberFromUser("Varenummer start")));
                        break;
                    case 4:
                        Inventorylist(Inventory.Items);
                        break;
                    case 5:
                        DeleteItem(Input.GetNumberFromUser("Varenummer"));
                        break;
                    case 6:
                        OrderScreen.OrderMenu();
                        break;
                    case 7:
                        Repeat = false;
                        break;
                    default:
                        UI.write("forkert input\n");
                        break;
                }
                
            } while (Repeat);

        }

        public static void CreateItem()
        {
            Item NewItem = new Item();
            NewItem.Itemnumber = Input.GetNumberFromUser("Varenummer");
            NewItem.name = Input.GetStringFromUser("Navn");
            NewItem.amount = Input.GetNumberFromUser("Antal");
            NewItem.SalePrice = Input.GetDoubleFromUser("Salgspris");
            NewItem.PurchasePrice = Input.GetDoubleFromUser("Indkøbspris");
            NewItem.Invetoryplace = Input.GetNumberFromUser("Lagerplads");
            Database.Insert(NewItem);
        }

        public static void Inventorylist(List<Item> items) //skriver alt info vi har om de vare vi har på en strukturet måde
        {
            Inventory.Items = Database.GetItems();
            Console.ForegroundColor = ConsoleColor.Green;
            UI.write("Varenummer");
            Console.CursorLeft = 20;
            UI.write("Navn");
            Console.CursorLeft = 40;
            UI.write("Antal");
            Console.CursorLeft = 60;
            UI.write("Salgspris");
            Console.CursorLeft = 80;
            UI.write("Indkøbspris");
            Console.CursorLeft = 100;
            UI.write("Lagerplads");
            Console.CursorLeft = 120;
            UI.write("ID\n");
            int i = 0;
            while (i < Console.WindowWidth - 1)
            {
                i++;
                UI.write("=");
            }
            foreach (Item item in items)
            {
                
                string ItemnumberSTR = item.Itemnumber.ToString();
                string amountSTR = item.amount.ToString();
                string SalepriceSTR = item.SalePrice.ToString();
                string PurchasePriceSTR = item.PurchasePrice.ToString();
                string InvetoryplaceSTR = item.Invetoryplace.ToString();
                string InvetoryIDSTR = item.ID.ToString();

                
                UI.write("\n");
                while (ItemnumberSTR.Length < 20)
                {
                    ItemnumberSTR += " ";
                }
                UI.write(ItemnumberSTR);
                Console.CursorLeft += 1;
                while (item.name.Length < 20)
                {
                    item.name += " ";
                }
                UI.write(item.name);
                Console.CursorLeft += 1;
                while (amountSTR.Length < 20)
                {
                    amountSTR += " ";
                }
                UI.write(amountSTR);
                Console.CursorLeft += 1;
                while (SalepriceSTR.Length < 20)
                {
                    SalepriceSTR += " ";
                }
                UI.write(SalepriceSTR);
                Console.CursorLeft += 1;
                while (PurchasePriceSTR.Length < 20)
                {
                    PurchasePriceSTR += " ";
                }
                UI.write(PurchasePriceSTR);
                Console.CursorLeft += 1;
                while (InvetoryplaceSTR.Length < 20)
                {
                    InvetoryplaceSTR += " ";
                }
                UI.write(InvetoryplaceSTR);
                Console.CursorLeft += 1;
                while (InvetoryIDSTR.Length < 20)
                {
                    InvetoryIDSTR += " ";
                }
                UI.write(InvetoryIDSTR);
                Console.CursorLeft += 1;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }


        
        public static void Rediger_vare(Item item)
        {
            UI.write("Tryk 1 for at redigere varenummer.\n" +
                "Tryk 2 for at redigere navn.\n" +
                "Tryk 3 for at redigere antal.\n" +
                "Tryk 4 for at redigere salgspris.\n" +
                "Tryk 5 for at redigere indkøbspris\n" +
                "Tryk 6 for at redigere lagerplads.\n");
            switch (Input.GetNumberFromUser("Hvad vil du redigere"))
            {
                case 1:
                    item.Itemnumber = Input.GetNumberFromUser("\n.Det gamle tal er " + item.Itemnumber + " hvad skal det være");
                    break;
                case 2:
                    UI.write("\nDet gamle navn er " + item.name + " hvad skal det være: ");
                    item.name = Console.ReadLine();
                    break;
                case 3:
                    item.amount = Input.GetNumberFromUser("\n.Det gamle tal er " + item.amount + " hvad skal det være");
                    break;
                case 4:
                    UI.write("\n.Det gamle tal er " + item.SalePrice + " hvad skal det være: ");
                    item.SalePrice = set_double(item.SalePrice);
                    break;
                case 5:
                    UI.write("\n.Det gamle tal er " + item.PurchasePrice + " hvad skal det være: ");
                    item.PurchasePrice = set_double(item.PurchasePrice);
                    break;
            }
            Database.Update(item);

        }

        public static double set_double(double sikkerhed = 1.0f)
        {
            double assignment;
            bool test = double.TryParse(Console.ReadLine(), out assignment);
            if (test)
            {
                return assignment;
            }
            else
            {
                Console.WriteLine("Tallet blev ikke ændret");
            }
            return sikkerhed;
        }

        public static int FindIndexItem(int search)
        {
            for(int indeks = 0;indeks <Inventory.Items.Count; indeks++)
            {
                if(Inventory.Items[indeks].Itemnumber == search)
                {
                    return indeks;
                }
            }
            return -1;
        }
        public static void DeleteItem(int Itemnumber)
        {
            Database.Delete(Inventory.Items[FindIndexItem(Itemnumber)]);
            Inventory.Items.RemoveAt(FindIndexItem(Itemnumber));
        }
    }

}
