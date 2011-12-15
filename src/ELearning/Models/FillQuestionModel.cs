using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data.Enums;

namespace ELearning.Models
{
    public class FillQuestionModel
    {
        public QuestionGroupTypes Type { get; private set; }
        public int QuestionInstanceID { get; private set; }

        public bool IsRequired { get; private set; }

        public object Answer { get; set; }


        /// <summary>
        /// Initializes a new instance of the FillQuestionModel class.
        /// </summary>
        public FillQuestionModel(QuestionGroupTypes type, int questionInstanceID, bool isRequired)
        {
            Type = type;
            QuestionInstanceID = questionInstanceID;
            IsRequired = isRequired;
        }
    }
}