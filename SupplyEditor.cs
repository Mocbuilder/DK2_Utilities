using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DK2_Utils
{
    public class SupplyEditor
    {
        internal string rootModsFolder { get; set; }
        internal SharedFuncs shared { get; set; }

        public SupplyEditor(SharedFuncs _shared)
        {
            rootModsFolder = ConfigurationManager.AppSettings["costumModsFolder"];
            shared = _shared;
        }


        public void EditSupply() 
        {
            string newValue = GetUserInput();

            string[] files = Directory.GetFiles(rootModsFolder, "*.xml", SearchOption.AllDirectories);
            
            foreach (string filePath in files)
            {
                UpdateSupplyValue(filePath, newValue);
            }
            Console.WriteLine(shared.GetLocalString("supplyEditor_finished"));
            Console.ReadLine();
        }

        internal string GetUserInput()
        {
            while (true)
            {
                //get the new value from the user
                Console.WriteLine(shared.GetLocalString("supplyEditor_newSupplyValue"));

                string userInput = Console.ReadLine();
                int newValue = 0;

                try
                {
                    newValue = Convert.ToInt32(userInput);
                    if (newValue < 0)
                        return "0";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                return newValue.ToString();
            }
        }

        internal void UpdateSupplyValue(string filePath, string newSupplyValue)
        {
            try
            {
                //load xml file and find the supply attribute, replace and log accordingly
                XDocument xmlDoc = XDocument.Load(filePath);

                var classElements = xmlDoc.Descendants("Class")
                                          .Where(e => e.Attribute("supply") != null);

                bool changesMade = false;

                foreach (var classElement in classElements)
                {
                    string oldSupplyValue = classElement.Attribute("supply")?.Value;
                    if (oldSupplyValue != newSupplyValue)
                    {
                        classElement.SetAttributeValue("supply", newSupplyValue);
                        changesMade = true;
                    }
                }

                //saven the updated xml
                if (changesMade)
                {
                    xmlDoc.Save(filePath);
                    Console.WriteLine(shared.GetLocalString("supplyEditor_fileUpdated") + filePath);
                }
                else
                {
                    Console.WriteLine(shared.GetLocalString("supplyEditor_fileNotUpdated") + filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(shared.GetLocalString("supplyEditor_fileError") + $"{filePath}: \n{ex}\n");
            }
        }
    }
}
