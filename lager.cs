using System.Collections.Generic;
using System.Linq;

namespace ERPsystem
{
    class lager
    {

        public static List<Inventory> vareListe = new List<Inventory>();
        //opretter en vare og definere alt i Vare classen
        public static void Opret_vare(int varenummer, string name, int antal, float salgspris, float indkøbspris, int lagerplads)
        {
            Inventory nyvare = new Inventory();
            nyvare.varenummer = varenummer;
            nyvare.name = name;
            nyvare.antal = antal;
            nyvare.salgspris = salgspris;
            nyvare.indkøbspris = indkøbspris;
            nyvare.lagerplads = lagerplads;
            vareListe.Add(nyvare);
        }
        

        //søger efter varenummer der matcher søgning
        public static List<Inventory> søg_vare(int serach)
        {
            IEnumerable<Inventory> quere =
                from vare in vareListe
                where find_str(vare.varenummer.ToString(), serach.ToString().Length) == serach.ToString()
                select (vare);
            List<Inventory> result = new();
            foreach (Inventory vare in quere)
            {
                result.Add(vare);
            }
            return result;
        }
        public static string find_str(string input, int length)
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output = output + input[i];
            }
            return output;
        }
    }

}
