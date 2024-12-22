using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        internal int GetUserInput()
        {
            //get the new value from the user
            string userInput = Console.ReadLine();

            return 0;
        }
    }
}
