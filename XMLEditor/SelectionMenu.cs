using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor
{
    internal class SelectionMenu
    {
        List<Squad> Squads {  get; set; }

        public SelectionMenu(List<Squad> squads)
        {
            Squads = squads;
        }

        internal void Display()
        {
            List<Squad> selected = new List<Squad>();
            int index = 0;
            ConsoleKey key;

            foreach (var squad in Squads)
            {
                squad.IsSelected = false;
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Use ↑/↓ to navigate, Enter to select, 'C' to confirm selection\n");

                // Display items with selection status
                for (int i = 0; i < Squads.Count; i++)
                {
                    if (i == index)
                        Console.ForegroundColor = ConsoleColor.Yellow; // Highlight current selection

                    Console.Write(Squads[i].IsSelected ? "[X] " : "[ ] ");
                    Console.WriteLine($"{Squads[i].Name} ({Squads[i].Unit})");

                    Console.ResetColor();
                }

                Console.WriteLine("\nPress 'C' to confirm selection.");

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < Squads.Count - 1) index++;
                        break;
                    case ConsoleKey.Enter:
                        Squads[index].IsSelected = !Squads[index].IsSelected;
                        break;
                }

            } while (key != ConsoleKey.C); // Confirm with 'C'

            // Display final selection
            Console.Clear();
            Console.WriteLine("You selected:");
            foreach (var item in Squads.Where(i => i.IsSelected))
            {
                Console.WriteLine($"- {item.Name} ({item.Unit})");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        
        }
    }
}
