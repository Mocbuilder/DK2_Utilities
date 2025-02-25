using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public Action Action { get; set; }

        public MenuItem(string name, Action action)
        {
            Name = name;
            Action = action;
        }
    }
}
