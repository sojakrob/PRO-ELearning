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
                    result.Add(new ChoiceQuestionInstanceModel(question));
                else if (questionType == typeof(ScaleQuestion))
                    throw new NotImplementedException();//result.Add(new ScaleQuestionModel(question as ScaleQuestion));
                else
                    result.Add(new QuestionInstanceModel(question));
            }

            return result;
        }
    }
}