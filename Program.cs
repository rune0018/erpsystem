using System;
using System.Collections.Generic;

namespace ERPsystem
{

    //todo
    //1. (bug)input kan ikke være kommatal

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
                        lagermenu(lager.vareListe);
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
        public static void lagermenu(List<Inventory> inventories)
        {
            bool gentag = true;
            do
            {
                write("Tryk på 1 for at oprette en vare\n");
                write("Tryk på 2 for at rette en vare\n");
                write("Tryk på 3 for at søge efter en vare\n");
                write("Tryk på 4 for at se listen af vare\n");
                write("Tryk på 5 for at fjerne fra lageret\n");
                write("Tryk på 6 for at afslutte pc'en\n");
                switch (GetTalFromUser(""))
                {
                    case 1:
                        opretvarer();
                        break;
                    case 2:
                        Rediger_vare(lager.vareListe[FindIndexLager(GetTalFromUser("Varenummer"))]);
                        break;
                    case 3:
                        Vareliste(lager.søg_vare(GetTalFromUser("Varenummer start")));
                        break;
                    case 4:
                        Vareliste(lager.vareListe);
                        break;
                    case 5:
                        lager.vareListe.RemoveAt(FindIndexLager(GetTalFromUser("Varenummer")));
                        break;
                    case 6:
                        gentag = false;
                        break;
                    default:
                        write("forkert input\n");
                        break;
                }
            } while (gentag);

        }

        public static void opretvarer()
        {
            Inventory nyvare = new Inventory();
            nyvare.varenummer = GetTalFromUser("Varenummer");
            nyvare.name = GetStringFromUser("Navn");
            nyvare.antal = GetTalFromUser("Antal");
            nyvare.salgspris = GetFloatFromUser("Salgspris");
            nyvare.indkøbspris = GetFloatFromUser("Indkøbspris");
            nyvare.lagerplads = GetTalFromUser("Lagerplads");
            lager.vareListe.Add(nyvare);
        }

        public static void Vareliste(List<Inventory> inventories) //skriver alt info vi har om de vare vi har på en strukturet måde
        {
            Console.Clear();
            Console.SetCursorPosition(9, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Inventory vare in inventories)
            {
                Console.CursorLeft = 9;
                string varenummerSTR = vare.varenummer.ToString();
                string antalSTR = vare.antal.ToString();
                string salgsprisSTR = vare.salgspris.ToString();
                string indkøbsprisSTR = vare.indkøbspris.ToString();
                string lagerPladsSTR = vare.lagerplads.ToString();
                while (varenummerSTR.Length < 20)
                {
                    varenummerSTR += " ";
                }
                write(varenummerSTR);
                Console.CursorLeft += 1;
                while (vare.name.Length < 20)
                {
                    vare.name += " ";
                }
                write(vare.name);
                Console.CursorLeft += 1;
                while (antalSTR.Length < 20)
                {
                    antalSTR += " ";
                }
                write(antalSTR);
                Console.CursorLeft += 1;
                while (salgsprisSTR.Length < 20)
                {
                    salgsprisSTR += " ";
                }
                write(salgsprisSTR);
                Console.CursorLeft += 1;
                while (indkøbsprisSTR.Length < 20)
                {
                    indkøbsprisSTR += " ";
                }
                write(indkøbsprisSTR);
                Console.CursorLeft += 1;
                while (lagerPladsSTR.Length < 20)
                {
                    lagerPladsSTR += " ";
                }
                write(lagerPladsSTR);
                Console.CursorLeft += 1;
                Console.CursorTop += 1;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }
        public static int GetTalFromUser(string hint)
        {
            Console.Write(hint + ": ");
            int svar;
            int.TryParse(Console.ReadLine(), out svar);
            return svar;
        }

        public static string GetStringFromUser(string hint)
        {
            Console.Write(hint + ": ");
            string svar = Console.ReadLine();
            return svar;
        }

        public static float GetFloatFromUser(string hint)
        {
            Console.Write(hint + ": ");
            float svar;
            float.TryParse(Console.ReadLine(), out svar);
            return svar;
        }

        public static void write(string skriv)
        {
            Console.Write(skriv);
        }
        public static void Rediger_vare(Inventory vare)
        {
            Console.Clear();
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

        public static float set_float(float sikkerhed = 1.0f)
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

        public static int FindIndexLager(int search)
        {
            for(int indeks = 0;indeks <lager.vareListe.Count; indeks++)
            {
                if(lager.vareListe[indeks].varenummer == search)
                {
                    return indeks;
                }
            }
            return -1;
        }
    }

}
