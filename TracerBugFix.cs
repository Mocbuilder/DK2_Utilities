using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DK2_Utils
{
    public class TracerBugFix
    {
        internal SharedFuncs shared { get; set; }
        internal string rootModsFolder { get; set; }

        public TracerBugFix (SharedFuncs _shared)
        {
            rootModsFolder = ConfigurationManager.AppSettings["costumModsFolder"];
            shared = _shared;
        }

        public void EditTracerBug()
        {
            string[] files = Directory.GetFiles(rootModsFolder, "*.xml", SearchOption.AllDirectories);

            foreach (string filePath in files)
            {
                UpdateTracerValues(filePath);
            }
            Console.WriteLine(shared.GetLocalString("supplyEditor_finished"));
            Console.ReadLine();
        }

        internal void UpdateTracerValues(string filePath)
        {
            try
            {
                //load xml file and find the supply attribute, replace and log accordingly
                XDocument xmlDoc = XDocument.Load(filePath);

                var classElements = xmlDoc.Descendants("Class")
                                          .Where(e => e.Attribute("TracerTemplate") != null);

                bool changesMade = false;

                foreach (var classElement in classElements)
                {
                    string oldSupplyValue = classElement.Attribute("supply")?.Value;
                    string newTracerValue = "";

                    switch (oldSupplyValue)
                    {
                        case "Tracer_Pistol_Gr_IoV":
                            newTracerValue = "Tracer_Pistol";
                            break;
                        case "Tracer_Rifle_Gr_IoV":
                            newTracerValue = "Tracer_Rifle";
                            break;
                        case "Tracer_LMG_Gr_IoV":
                            newTracerValue = "Tracer_LMG";
                            break;
                        case "Tracer_Silenced_Gr_IoV":
                            newTracerValue = "Tracer_Pistol";
                            break;
                        default:
                            newTracerValue = "Tracer_Pistol";
                            break;
                    }

                    classElement.SetAttributeValue("supply", newTracerValue);
                    changesMade = true;
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
    }
}
