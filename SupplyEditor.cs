using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DK2_Utils
{
    public class SupplyEditor
    {
        public string rootModsFolder { get; set; }

        public SupplyEditor(string _rootModsFolder)
        {
            rootModsFolder = _rootModsFolder;
        }


        public void EditSupply() 
        {
            int newValue = GetUserInput();

            string[] files = Directory.GetFiles(rootModsFolder, "*.xml", SearchOption.AllDirectories);
            
            foreach (string filePath in files)
            {
                XMLFile_SR(filePath, "", "");
            }
        }

        internal int GetUserInput()
        {
            while (true)
            {
                //get the new value from the user
                Console.WriteLine("To learn how the values relate to the unit points in-game, please read the documentation\nEnter the new supply value:");

                string userInput = Console.ReadLine();
                int newValue = 0;

                try
                {
                    newValue = Convert.ToInt32(userInput);
                    if (newValue < 0)
                        return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                return newValue;
            }
        }

        internal void XMLFile_SR(string filePath, string search, string replace)
        {
            //search the file, replace if something is found and log accordingly
            string text = File.ReadAllText(filePath);

            string modifiedText = text.Replace(search, replace);

            if (text.StartsWith(modifiedText))
            {
                Console.WriteLine($"Nothing found at: {filePath}");
                return;
            }   

            File.WriteAllText(filePath, modifiedText);
            Console.WriteLine($"Replaced target text at: {filePath}");
        }
    }
}
