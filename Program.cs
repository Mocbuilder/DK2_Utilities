using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IO;

namespace DK2_Utils
{
    internal class Program
    {
        static SharedFuncs shared = new SharedFuncs();

        static void Main(string[] args)
        {
            SupplyEditor supplyEditor = null;
            TracerBugFix tracerBugFix = null;

            string firstLaunch = ConfigurationManager.AppSettings["firstLaunch"];

            bool IsfirstLaunch = Convert.ToBoolean(firstLaunch);

            //Init some values and method instances if its first launch
            if (IsfirstLaunch == true)
            {
                //its the first launch
                GetSetUserLanguage();
                GetUserModsFolder();
                supplyEditor = new SupplyEditor(shared);
                tracerBugFix = new TracerBugFix(shared);
                shared.SetAppSetting("firstLaunch", "false");
            }
            else
            {
                //its not the first launch
                SharedFuncs.culture = ConfigurationManager.AppSettings["culture_string"];
                supplyEditor = new SupplyEditor(shared);
                tracerBugFix = new TracerBugFix(shared);
            }

            Console.CursorVisible = true;

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
                        tracerBugFix.EditTracerBug();
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
            shared.SetAppSetting("culture_string", culture);
        }

        public static void GetUserModsFolder()
        {
            while (true)
            {
                //ask for path to modsfolder and loop till its valid
                Console.WriteLine(shared.GetLocalString("question_modsFolder"));
                string path = Console.ReadLine();

                if (Directory.Exists(path))
                {
                    shared.SetAppSetting("costumModsFolder", path);
                    return;
                }

                Console.WriteLine(shared.GetLocalString("invalid_path"));
            }
        }
    }
}
