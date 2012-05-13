using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Data
{
    public partial class ChoiceQuestion
    {
        public override void CopyPropertiesTo(Question question)
        {
            base.CopyPropertiesTo(question);

            ChoiceQuestion q = question as ChoiceQuestion;
            if (q == null)
                return;

            q.Shuffle = this.Shuffle;
        }
    }
}
