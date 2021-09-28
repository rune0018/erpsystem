using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Costumor
{
    class CostumomerScreen
    {
        public static void CustumorMeneu()
        {
            bool repeat = true;
            do
            {
                UI.write("Tryk på 1 for at få en kundeliste\n");
                UI.write("Tryk på 2 for at oprette en kunde\n");
                UI.write("Tryk på 3 for at redigere en kunde\n");
                UI.write("Tryk på 4 for at søge efter en kunde\n");
                UI.write("Tryk på 5 for at lukke menu'en\n");
                int awnser = Input.GetNumberFromUser("hvad vil du");
                Console.Clear();
                switch (awnser)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        repeat = false;
                        break;
                }
            } while (repeat);
        }
        public static void ShowCostumors()
        {
            UI.write("Kundenummer");
            Console.CursorLeft = 20;
            UI.write("PersonID");
            Console.CursorLeft = 40;
            UI.write("");
        }
    }
}
