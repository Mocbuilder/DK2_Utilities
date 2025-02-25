namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayMenuTest();
        }

        private static void DisplayMenuTest()
        {
            // Create menu items
            MenuItem item1 = new MenuItem("Item 1", Nothing);
            MenuItem item2 = new MenuItem("Item 2", () => { Console.WriteLine("Item 2 selected"); });
            MenuItem item3 = new MenuItem("Item 3", () => { Console.WriteLine("Item 3 selected"); });
            // Create list menu
            ListMenu menu = new ListMenu(new List<MenuItem> { item1, item2, item3 });
            // Display menu
            menu.Display();
        }

        private static void Nothing()
        {
            Console.WriteLine("Item 1 selected");
            Console.ReadLine();
        }
    }
}
