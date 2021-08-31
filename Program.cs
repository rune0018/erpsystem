using System;
using System.Collections.Generic;
using System.Linq;

namespace ERPsystem
{

    //todo
    //1. lagermenu
    //2. opretvare
    //3. vareliste med liste af vare
    //4. søgning igennem lager
    class Program
    {
        static void Main(string[] args)
        {
            lager.Opret_vare(1, "hej", 2, 0.2f, 0.5f, 6);
            Skærm.hovedmenu();
        }
    }
    static class Skærm
    {
        public static void hovedmenu()
        {
            bool gentag = true;
            do
            {
                Console.Clear();
                write("Tryk på 1 for at se lagerts pc\n");
                write("Tryk på 2 for at se ordre pc'en (virker ikke)\n");
                write("Tryk på 3 for at se ansættelse pc'en (virker ikke)\n");
                switch (GetTalFromUser("Hvilken pc vil du bruge"))
                {
                    case 1:
                        lagermenu();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }

            } while (gentag);
        }
        public static void lagermenu()
        {
            write("Tryk på 1 for at oprette en vare\n");
            write("Tryk på 2 for at rette en vare\n");
            write("Tryk på 3 for at se listen over varer\n");
            switch (GetTalFromUser(""))
            {
                case 1:
                    break;
                case 2:
                    
                    break;
                case 3:
                    break;
                default:
                    write("forkert input");
                    lagermenu();
                    break;
            }
        }
        public static void opretvarer()
        {

        }
        public static void Vareliste() //skriver alt info vi har om de vare vi har på en strukturet måde
        {
            Console.SetCursorPosition(9, 5);
            Console.BackgroundColor = ConsoleColor.Blue;
            int offset = 0;
            foreach (Inventory vare in lager.vareListe)
            {
                //while(vare.varenummer.Length < 20)
                //{
                //    vare.varenummer = vare.varenummer + " ";
                //}
                //Console.Write(vare.varenummer);
                //Console.SetCursorPosition(30, 5 + offset);
                //while (vare.name.Length < 20)
                //{
                //    vare.name += " ";
                //}
                //Console.Write(vare.name);
            }
        }
        public static int GetTalFromUser(string hint)
        {
            Console.Write(hint + ": ");
            int svar;
            int.TryParse(Console.ReadLine(), out svar);
            return svar;
        }
        public static void write(string skriv)
        {
            Console.Write(skriv);
        }
        public static void Rediger_vare(Inventory vare)
        {
            Skærm.write("Tryk 1 for at redigere varenummer.\n" +
                "Tryk 2 for at redigere navn.\n" +
                "Tryk 3 for at redigere antal.\n" +
                "Tryk 4 for at redigere salgspris.\n" +
                "Tryk 5 for at redigere indkøbspris\n" +
                "Tryk 6 for at redigere lagerplads.\n");
            switch (GetTalFromUser("Hvad vil du redigere"))
            {
                case 1:
                    vare.varenummer = GetTalFromUser("\n.Det gamle tal er " + vare.varenummer + " hvad skal det være");
                    break;
                case 2:
                    write("\nDet gamle navn er " + vare.name + " hvad skal det være: ");
                    vare.name = Console.ReadLine();
                    break;
                case 3:
                    vare.antal = GetTalFromUser("\n.Det gamle tal er " + vare.antal + " hvad skal det være");
                    break;
                case 4:
                    write("\n.Det gamle tal er " + vare.salgspris + " hvad skal det være: ");
                    vare.salgspris = set_float(vare.salgspris);
                    break;
                case 5:
                    write("\n.Det gamle tal er " + vare.indkøbspris + " hvad skal det være: ");
                    vare.indkøbspris = set_float(vare.indkøbspris);
                    break;
            }

        }
        public static float set_float(float sikkerhed)
        {
            float assignment;
            bool test = float.TryParse(Console.ReadLine(), out assignment);
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
    }
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
            return (List<Inventory>)quere;
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
