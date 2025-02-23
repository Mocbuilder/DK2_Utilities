

using System;
using System.Transactions;
using System.Xml.Linq;

namespace XMLEditor
{
    public class XMLEditor
    {
        #region  temp test stuff incl main
        public static Dictionary<string, Delegate> temp_Functions = new Dictionary<string, Delegate>()
        {
            { "Test", (Action)Test },
            { "GetSelectSquads", (Func<List<Squad>>)new XMLEditor().GetSelectSquads },
        };

        static void Main()
        {
            Console.WriteLine("Console is temporary, the functions are forever!");

            while (true)
            {
                Console.WriteLine("\nAvailable Functions:");
                int index = 1;
                foreach (var function in temp_Functions)
                {
                    Console.WriteLine($"{index}. {function.Key}");
                    index++;
                }

                Console.Write("Choose a function (or type 0 to exit): ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0) break;

                if (choice > 0 && choice <= temp_Functions.Count)
                {
                    string selectedFunction = new List<string>(temp_Functions.Keys)[choice - 1];
                    ExecuteFunction(selectedFunction);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        static void ExecuteFunction(string functionName)
        {
            if (!temp_Functions.ContainsKey(functionName))
            {
                Console.WriteLine("Function not found.");
                return;
            }

            Delegate function = temp_Functions[functionName];

            if (function is Action action)
            {
                action();
            }
            else if (function is Func<List<Squad>> squadFunc)
            {
                var result = squadFunc();
                Console.WriteLine($"Function {functionName} returned {result.Count} squads.");
            }
            else if (function is Func<int> intFunc)
            {
                int result = intFunc();
                Console.WriteLine($"Function {functionName} returned {result}");
            }
            else
            {
                Console.WriteLine("Unsupported function type.");
            }
        }

        static void Test()
        {
            Console.WriteLine("test");
        }
        #endregion  temp test stuff incl main
        //asd
        public List<Squad> GetSelectSquads()
        {
            List<Squad> availableSquads = new List<Squad>();
            List<Squad> selectedSquads = new List<Squad>();

            XDocument rosterxml = new XDocument();
            rosterxml = XDocument.Load(DK2Utils_Shared.Filepaths.roster);

            var rosterElements = rosterxml.Descendants("Roster");
            var squadElements = rosterElements.Descendants("Squad");
            foreach (var squadElement in squadElements)
            {
                Squad tempSquad = new Squad(squadElement.Attribute("unit")?.Value, squadElement.Attribute("name")?.Value, squadElement.Attribute("id")?.Value, Convert.ToInt32(squadElement.Attribute("battleHonors")?.Value));
                availableSquads.Add(tempSquad);
            }

            SelectionMenu menu = new SelectionMenu(availableSquads);
            menu.Display();

            foreach (var squad in availableSquads)
            {
                if (squad.IsSelected)
                {
                    selectedSquads.Add(squad);
                }
            }

            return selectedSquads;
        }

        public void EditSquadBHValue(Squad squad, int newValue)
        {
            XDocument rosterxml = new XDocument();
            rosterxml = XDocument.Load(DK2Utils_Shared.Filepaths.roster);

            var rosterElement = rosterxml.Descendants("Roster");
            var SquadElements = rosterElement.Descendants("Squad");

            foreach(var tempsquad in SquadElements)
            {
                if(tempsquad.Attribute("id").Value == squad.ID)
                {
                    tempsquad.Attribute("battlehonors").Value = newValue.ToString();
                }
            }
        }
    }
}
