using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drawee.BL
{
    public class DrawerService
    {
        private static readonly Lazy<DrawerService> instance = new Lazy<DrawerService>(() => new DrawerService());
        public static DrawerService Instance => instance.Value;

        private DrawerService() { }
     
        
    }
}