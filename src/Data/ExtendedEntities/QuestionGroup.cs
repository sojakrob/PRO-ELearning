using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Shared;

namespace ELearning.Data
{
    public partial class QuestionGroup
    {
        public Enums.QuestionGroupTypes TypeEnum
        {
            get { return EnumUtility.EnumFromName<Enums.QuestionGroupTypes>(Type.Name); }
        }

        public virtual void CopyPropertiesTo(QuestionGroup questionGroup)
        {
            questionGroup.IsRequired = this.IsRequired;
            questionGroup.QuestionGroupTypeID = this.QuestionGroupTypeID;
        }
    }
}
