using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using System.Data.Objects.DataClasses;

namespace ELearning.Models.Data
{
    public class ScaleQuestionModel : QuestionModel
    {
        public ScaleQuestionModel()
        {
            
        }
        public ScaleQuestionModel(Question data)
            : base(data)
        {
            
        }
        public ScaleQuestionModel(ScaleQuestion data)
            : base(data as Question)
        {

        }
    }
}
