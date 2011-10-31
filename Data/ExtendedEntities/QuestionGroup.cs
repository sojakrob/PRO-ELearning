using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Shared;

namespace ELearning.Data
{
    public partial class QuestionGroup
    {
        public Enums.QuestionTypes TypeEnum
        {
            get { return EnumUtility.EnumFromName<Enums.QuestionTypes>(Type.Name); }
        }
    }
}
