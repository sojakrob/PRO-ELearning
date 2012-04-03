using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Data
{
    public partial class ChoiceAnswer
    {
        public override string ToString()
        {
            return ChoiceItemTemplate.Text;
        }
    }
}
