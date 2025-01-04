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
        internal string folderPath { get; set; }
        internal SharedFuncs shared { get; set; }
        internal Dictionary<string, string> mods = new Dictionary<string, string> { };

        public SupplyEditor(SharedFuncs _shared)
        {
            shared = _shared;
        }


        public void EditSupply() 
        {
            string userInput = GetUserInput();
            
            string[] files = Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);
            
            foreach (string filePath in files)
            {
                UpdateSupplyValue(filePath, userInput);
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

                string inputNewValue = Console.ReadLine();
                int newValue = 0;
                string resultSupplyValue = "";
                string resultGameFolder = "";

                try
                {
                    newValue = Convert.ToInt32(inputNewValue);
                    if (newValue < 0)
                        resultSupplyValue = "0";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                resultSupplyValue = newValue.ToString();

                Console.WriteLine(shared.GetLocalString("supplyEditor_applyToVanilla"));
                string inputVanilla = Console.ReadLine();
                if (inputVanilla == "n")
                {
                    folderPath = shared.GetAppSetting("costumModsFolder");
                    return resultSupplyValue;
                }

                folderPath = shared.GetAppSetting("costumGameFolder");
                return resultSupplyValue;
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

                //save the updated xml
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

        internal void GetAvailableMods()
        {
            string[] files = Directory.GetFiles(shared.GetAppSetting("costumModsFolder"), "mod.xml", SearchOption.AllDirectories);

            try
            {
                foreach (var file in files)
                {
                    XDocument xmlDoc = XDocument.Load(file);

                    var classElements = xmlDoc.Descendants("Mod")
                                              .Where(e => e.Attribute("title") != null);

                    bool changesMade = false;

                    foreach (var classElement in classElements)
                    {
                        string title = classElement.Attribute("title")?.Value;

                        mods.Add(title, file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(shared.GetLocalString("supplyEditor_fileError") + $"indexing all available mods: \n{ex}\n");
            }
        }
    }
}
