using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK2_Utils
{
    public class TracerBugFix
    {
        internal SharedFuncs shared { get; set; }

        public TracerBugFix (SharedFuncs _shared)
        {
            shared = _shared;
        }
    }
}
