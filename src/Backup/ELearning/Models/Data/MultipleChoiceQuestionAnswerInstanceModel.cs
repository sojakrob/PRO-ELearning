using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class MultipleChoiceQuestionAnswerInstanceModel : ChoiceQuestionInstanceModel
    {
        public int[] AnswerItems { get; private set; }


        public MultipleChoiceQuestionAnswerInstanceModel()
        {
            AnswerItems = new int[0];
        }
        public MultipleChoiceQuestionAnswerInstanceModel(QuestionInstance data)
            : base(data)
        {
            var answer = data.Answer as MultipleChoiceAnswer;
            if (answer != null)
            {
                AnswerItems = new int[answer.Items.Count];
                var answers = answer.Items.ToArray();
                for (int i = 0; i < answer.Items.Count; i++)
                    AnswerItems[i] = answers[i].ChoiceItemID;
            }
        }
    }
}
