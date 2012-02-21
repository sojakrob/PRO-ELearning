using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using System.Data.Objects.DataClasses;

namespace ELearning.Models.Data
{
    public class QuestionInstanceModelsConverter
    {
        public static List<QuestionInstanceModel> CreateFromArray(EntityCollection<QuestionInstance> questions)
        {
            var result = new List<QuestionInstanceModel>();
            foreach (var question in questions)
            {
                Type questionType = question.QuestionTemplate.GetType();

                if (questionType == typeof(ChoiceQuestion))
                {
                    result.Add(new ChoiceQuestionAnswerInstanceModel(question));
                }
                else if (questionType == typeof(ScaleQuestion))
                {
                    result.Add(new ScaleQuestionAnswerInstanceModel(question));
                }
                else
                {
                    result.Add(new TextQuestionAnswerInstanceModel(question));
                }
            }

            return result;
        }
    }
}