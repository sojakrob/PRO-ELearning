using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Data
{
    public partial class MultipleChoiceAnswer
    {
        private const string DELIMITER = ", ";


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in Items)
            {
                result.Append(item.ChoiceItemTemplate.Text);
                result.Append(DELIMITER);
            }

            if (result.Length >= DELIMITER.Length)
                result.Remove(result.Length - DELIMITER.Length, DELIMITER.Length);

            return result.ToString();
        }
    }
}
