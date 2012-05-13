using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Data
{
    public partial class ScaleQuestion
    {
        public override void CopyPropertiesTo(Question question)
        {
            base.CopyPropertiesTo(question);

            ScaleQuestion q = question as ScaleQuestion;
            if (q == null)
                return;

            q.MinValue = this.MinValue;
            q.MinValueText = this.MinValueText;
            q.MaxValue = this.MaxValue;
            q.MaxValueText = this.MaxValueText;
            q.Increment = this.Increment;
        }
    }
}
