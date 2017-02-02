using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drawee
{
    public class Drawer
    {
        public string Name { get; set; }
        public bool IsGuest { get; set; }
        public bool Picked { get; set; }
        public string Icon { get; set; }
        public string Refsheet { get; set; }
        public IEnumerable<string> InterestingLinks { get; set; }

        public Drawer() { }

        public Drawer(string name, string icon)
        {
            Name = name;
            Icon = icon;
        }    
    }
}