using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class ScaleQuestionAnswerInstanceModel : ScaleQuestionInstanceModel
    {
        public int? Answer { get; set; }

        public ScaleQuestionAnswerInstanceModel()
        {
            Answer = null;
        }
        public ScaleQuestionAnswerInstanceModel(QuestionInstance data)
            : base(data)
        {
            var answer = data.Answer as ScaleAnswer;
            if (answer != null)
                Answer = answer.Value;
        }
    }
}
