using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Reflection;

namespace ELearning
{
    public class DisplayLocalized : DisplayNameAttribute
    {
        public DisplayLocalized(string key)
            : base(key)
        {
            
        }


        public override string DisplayName
        {
            get
            {
                return Localization.GetResourceString(base.DisplayNameValue);
            }
        }
    }
}