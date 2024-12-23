﻿using Newtonsoft.Json.Linq;

namespace DK2_Utils
{
    internal class Program
    {
        static SharedFuncs shared = new SharedFuncs();

        static void Main(string[] args)
        {
            //Init some values and method instances
            GetSetUserLanguage();

            Console.CursorVisible = true;

            SupplyEditor supplyEditor = new SupplyEditor(GetUserModsFolder());

            string[] options = new string[]
            {
                //get the culture specific strings
                shared.GetLocalString("menuItem_supply"),
                shared.GetLocalString("menuItem_iov"),
                shared.GetLocalString("menuItem_exit")
            };

            //Create menu instance and use it in an infinite loops
            Menu menu = new Menu(options);

            while (true)
            {
                int userChoice = menu.GetMenu();

                Console.CursorVisible = true;
                switch (userChoice)
                {
                    case 0:
                        supplyEditor.EditSupply();
                        break;
                    case 1:
                        Console.WriteLine("[PlaceHolder] IoV Tracer BugFix");
                        Console.ReadLine();
                        break;
                    case 2:
                        Environment.Exit(0);
                        return;
                }
            }

        }

        static void GetSetUserLanguage()
        {
            //Ask the User what language he wants and set the culture string in shared appropriatly
            string culture;

            string[] languages = new string[]
            {
                "English (GB)",
                "Deutsch (GER)"
            };

            Menu langMenu = new Menu(languages);

            int userChoice = langMenu.GetMenu();

            //check user choice to appropriatly set the culture string
            switch (userChoice)
            {
                case 0:
                    Console.WriteLine("Language set to: English (GB|US)");
                    culture = "en-GB";
                    break;
                case 1:
                    Console.WriteLine("Sprache ausgewählt: Deutsch (GER)");
                    culture = "de-GER";
                    break;
                default:
                    Console.WriteLine("How did we get here ?");
                    Console.WriteLine("Language set to: English (GB|US)");
                    culture = "en-GB";
                    break;
            }

            SharedFuncs.culture = culture;
        }

        public static string GetUserModsFolder()
        {
            while (true)
            {
                //ask for path to modsfolder and loop till its valid
                Console.WriteLine(shared.GetLocalString("question_modsFolder"));
                string path = Console.ReadLine();

                if (Directory.Exists(path))
                    return path;

                Console.WriteLine("Invalid path.");
            }
        }
    }
}
