using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DK2_Utils
{
    public class SharedFuncs
    {
        public static string culture = "en-GB";

        public string GetLocalString(string name)
        {
            //Get the requested string for the specified culture from the json file
            try
            {
                var json = File.ReadAllText("localization.json");
                var localization = JObject.Parse(json);

                return localization[culture][name].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "";
            }
        }

        public void SetAppSetting(string key, string value)
        {
            //update a value in app.config that already exists
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            if (config.AppSettings.Settings[key] != null)
            {
                config.AppSettings.Settings[key].Value = value;
            }
            else
            {
                GetLocalString("setAppSetting_keyNotFound");
            }
            config.Save(ConfigurationSaveMode.Modified);

            //refresh app.config in memory
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
