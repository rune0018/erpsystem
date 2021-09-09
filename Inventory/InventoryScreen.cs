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
                        Rediger_vare(Inventory.Items[FindIndexInventory(Input.GetNumberFromUser("Varenummer"))]);
                        break;
                    case 3:
                        Inventorylist(Inventory.SerchInventory(Input.GetNumberFromUser("Varenummer start")));
                        break;
                    case 4:
                        Inventorylist(Inventory.Items);
                        break;
                    case 5:
                        Inventory.Items.RemoveAt(FindIndexInventory(Input.GetNumberFromUser("Varenummer")));
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
            Inventory.Items.Add(NewItem);
        }

        public static void Inventorylist(List<Item> inventories) //skriver alt info vi har om de vare vi har på en strukturet måde
        {
            
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
            UI.write("Lagerplads\n");
            int i = 0;
            while (i < Console.WindowWidth - 1)
            {
                i++;
                UI.write("=");
            }
            foreach (Item vare in inventories)
            {
                
                string ItemnumberSTR = vare.Itemnumber.ToString();
                string amountSTR = vare.amount.ToString();
                string SalepriceSTR = vare.SalePrice.ToString();
                string PurchasePriceSTR = vare.PurchasePrice.ToString();
                string InvetoryplaceSTR = vare.Invetoryplace.ToString();

                
                UI.write("\n");
                while (ItemnumberSTR.Length < 20)
                {
                    ItemnumberSTR += " ";
                }
                UI.write(ItemnumberSTR);
                Console.CursorLeft += 1;
                while (vare.name.Length < 20)
                {
                    vare.name += " ";
                }
                UI.write(vare.name);
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
                while (InvetoryplaceSTR.Length < 10)
                {
                    InvetoryplaceSTR += " ";
                }
                UI.write(InvetoryplaceSTR);
                Console.CursorLeft += 1;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }


        
        public static void Rediger_vare(Item vare)
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
                    vare.Itemnumber = Input.GetNumberFromUser("\n.Det gamle tal er " + vare.Itemnumber + " hvad skal det være");
                    break;
                case 2:
                    UI.write("\nDet gamle navn er " + vare.name + " hvad skal det være: ");
                    vare.name = Console.ReadLine();
                    break;
                case 3:
                    vare.amount = Input.GetNumberFromUser("\n.Det gamle tal er " + vare.amount + " hvad skal det være");
                    break;
                case 4:
                    UI.write("\n.Det gamle tal er " + vare.SalePrice + " hvad skal det være: ");
                    vare.SalePrice = set_double(vare.SalePrice);
                    break;
                case 5:
                    UI.write("\n.Det gamle tal er " + vare.PurchasePrice + " hvad skal det være: ");
                    vare.PurchasePrice = set_double(vare.PurchasePrice);
                    break;
            }

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

        public static int FindIndexInventory(int search)
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
    }

}
