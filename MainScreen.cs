using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem
{
    class MainScreen
    {
        public static void Mainmenu()
        {
            bool Repeat = true;
            do
            {
                Console.Clear();
                UI.write("Tryk på 1 for at se lagerts pc\n");
                UI.write("Tryk på 2 for at se kunde pc'en\n");
                UI.write("Tryk på 3 for at se ansættelse pc'en (virker ikke)\n");
                int awnser = Input.GetNumberFromUser("Hvilken pc vil du bruge");
                Console.Clear();
                switch (awnser)
                {
                    case 1:
                        InventoryScreen.InventoryMenu(Inventory.Items);
                        break;
                    case 2:
                        CostumomerScreen.CustumorMeneu();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            } while (Repeat);
        }
    }
}
