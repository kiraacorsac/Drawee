using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drawee
{
    public class Drawer
    {
        public string Name { get; set; }
        public IEnumerable<string> RefsheetLinks { get; set; }
        public bool IsGuest { get; set; }

        public Drawer() { }

        public Drawer(string name, IEnumerable<string> refsheetLinks, bool guest = false)
        {
            Name = name;
            IsGuest = guest;

            RefsheetLinks = refsheetLinks;
        }    
    }
}