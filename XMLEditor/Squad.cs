using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor
{
    public class Squad : DK2Utils_Shared.Squad
    {
        internal string Unit {  get; set; }
        internal string Name { get; set; }
        internal string ID { get; set; }
        internal int Battlehonors { get; set; }

        internal bool IsSelected { get; set; } = false;

        public Squad(string unit, string name, string id, int battlehonors) :base (unit, name, id, battlehonors)
        {
            Unit = unit;
            Name = name;
            ID = id;
            Battlehonors = battlehonors;
        }
    }
}
