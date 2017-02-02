using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drawee.BL
{
    public class UIException : Exception
    {
        public UIException(string message) : base(message)
        {
        }
    }
}