using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class ChoiceQuestionAnswerInstanceModel : ChoiceQuestionInstanceModel
    {
        public int? Answer { get; set; }


        public ChoiceQuestionAnswerInstanceModel()
        {
            Answer = null;
        }
        public ChoiceQuestionAnswerInstanceModel(QuestionInstance data)
            : base(data)
        {
            var answer = data.Answer as ChoiceAnswer;
            if (answer != null)
                Answer = answer.ItemID;
        }
    }
}
