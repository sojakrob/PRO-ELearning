using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using System.Data.Objects.DataClasses;

namespace ELearning.Models.Data
{
    public class QuestionModelsConvertor
    {
        public static List<QuestionModel> CreateFromArray(EntityCollection<Question> questions)
        {
            var result = new List<QuestionModel>();
            foreach (var question in questions)
            {
                Type questionType = question.GetType();

                if (questionType == typeof(ChoiceQuestion))
                    result.Add(new ChoiceQuestionModel(question as ChoiceQuestion));
                else if (questionType == typeof(ScaleQuestion))
                    result.Add(new ScaleQuestionModel(question as ScaleQuestion));
                else
                    result.Add(new QuestionModel(question));
            }

            return result;
        }
    }
}
