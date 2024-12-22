using Newtonsoft.Json.Linq;

namespace DK2_Utils
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SharedFuncs shared = new SharedFuncs();
            string culture = GetSetUserLanguage();

            SharedFuncs.culture = culture;

            string[] options = new string[]
            {
                shared.GetLocalString("menuItem_supply"),
                shared.GetLocalString("menuItem_iov"),
                shared.GetLocalString("menuItem_exit")
            };

            Menu menu = new Menu(options);
            menu.GetMenu();
        }

        static string GetSetUserLanguage()
        {
            string culture;

            string[] languages = new string[]
            {
                "English (GB)",
                "Deutsch (GER)"
            };

            Menu langMenu = new Menu(languages);

            int userChoice = langMenu.GetMenu();

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

            return culture;
        }
    }
}
