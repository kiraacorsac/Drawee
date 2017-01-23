using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drawee.BL
{
    public class DrawerService
    {
        private static DrawerService instance;
        private DrawerService() { }
        public static DrawerService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DrawerService();
                }
                return instance;
            }
        }

        public IList<Drawer> GetCommonUsers()
        {
            return new List<Drawer>{
                new Drawer ("Kiraa", new[] { "lisk" }),
                new Drawer ("Mlpard", new[] { "delf", "lisk" })
            };
        }
    }
}