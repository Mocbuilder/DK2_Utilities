using System;
using System.Collections.Generic;
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
    }
}
