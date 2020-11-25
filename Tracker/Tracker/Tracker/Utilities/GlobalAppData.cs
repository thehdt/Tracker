using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Utilities
{
    public static class GlobalAppData
    {
        public static ResourceManager RM = new ResourceManager("Tracker.Resources.en", Assembly.GetExecutingAssembly());
    }
}
