using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Shared;

namespace ELearning.Data
{
    public partial class Form
    {
        public Enums.FormTypes TypeEnum
        {
            get { return EnumUtility.EnumFromName<Enums.FormTypes>(Type.Name); }
        }
    }
}
