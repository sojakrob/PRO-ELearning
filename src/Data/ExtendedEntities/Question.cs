using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Data
{
    public partial class Question
    {
        public virtual void CopyPropertiesTo(Question question)
        {
            question.Text = this.Text;
            question.HelpText = this.HelpText;
            question.Explanation = this.Explanation;
        }
    }
}
