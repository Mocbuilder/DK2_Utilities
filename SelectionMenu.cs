using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK2_Utils
{
    public class SelectionMenu
    {
        public static Dictionary<string, string> mods = new Dictionary<string, string> { };
        public static string[] menuItems { get; set; }

        public SelectionMenu(Dictionary<string, string> _mods)
        {
            mods = _mods;
            menuItems = Array.Empty<string>();
        }

        public string[] GetSelectionMenu()
        {
            menuItems = mods.Keys.ToArray();
            string[] result = Array.Empty<string>();

            //create menu and monitor input
            int selectedIndex = 0;

            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                DisplayMenu(selectedIndex);

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % menuItems.Length;
                        break;
                    case ConsoleKey.Enter:
                        //make background green if its not selected before and black when it is selected before
                        //return selectedIndex;
                        break;
                }
            }
        }

        static void DisplayMenu(int selectedIndex)
        {
            //Write the menu to the console
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    //give special background and font colour when its the selected item
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine(menuItems[i]);
            }
            Console.ResetColor();
        }
    }
}
