using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Data
{
    public class QuestionModel : DataModelBase<Question>
    {
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        public string HelpText { get; set; }
        public string Explanation { get; set; }
        public int QuestionGroupID { get; set; }
        public int FormID { get; private set; }


        public QuestionModel()
        {

        }
        public QuestionModel(Question data)
            : base(data)
        {
            ID = data.ID;
            Text = data.Text;
            HelpText = data.HelpText;
            Explanation = data.Explanation;
            QuestionGroupID = data.QuestionGroupID;

            if(data.QuestionGroup != null)
                FormID = data.QuestionGroup.FormTemplateID;
        }


        public override Question ToData()
        {
            return QuestionManager.CreateNewQuestion(
                ID,
                Text,
                HelpText,
                Explanation,
                QuestionGroupID
                );
        }
    }
}