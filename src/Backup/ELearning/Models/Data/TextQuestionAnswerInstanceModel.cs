using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class TextQuestionAnswerInstanceModel : QuestionInstanceModel
    {
        public string Answer { get; set; }


        public TextQuestionAnswerInstanceModel()
        {
            Answer = null;
        }
        public TextQuestionAnswerInstanceModel(QuestionInstance data)
            : base(data)
        {
            var answer = data.Answer as TextAnswer;
            if (answer != null)
                Answer = answer.Text;
        }
    }
}
