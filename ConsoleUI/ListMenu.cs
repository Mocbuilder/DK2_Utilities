using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class ListMenu
    {
        List<MenuItem> Items { get; set; }

        public ListMenu(List<MenuItem> items)
        {
            Items = items;
        }

        internal void Display()
        {           
            int index = 0;
            ConsoleKey key;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Use ↑/↓ to navigate, Enter to select.\n");

                // Display items with selection status
                for (int i = 0; i < Items.Count; i++)
                {
                    if (i == index)
                        Console.ForegroundColor = ConsoleColor.Blue; // Highlight current selection

                    Console.WriteLine($"{Items[i].Name}");

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < Items.Count - 1) index++;
                        break;
                    case ConsoleKey.Enter:
                        Items[index].Action.Invoke();
                        break;
                }
            };
        }
    }
}
