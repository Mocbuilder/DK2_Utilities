using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK2_Utils
{
    public class Menu
    {
        public static string[] menuItems { get; set; }

        public Menu(string[] MenuItems)
        {
            menuItems = MenuItems;
        }

        public int GetMenu()
        {
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
                        Console.Clear();
                        return selectedIndex;
                }
            }
        }

        static void DisplayMenu(int selectedIndex)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
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
