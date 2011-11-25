using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class QuestionModel : DataModelBase<Question>
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string HelpText { get; set; }
        public string Explanation { get; set; }
        public int QuestionGroupID { get; set; }


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
        }
        



        public override Question ToData()
        {
            return QuestionManager.CreateNewQuestionInstance(
                ID,
                Text,
                HelpText,
                Explanation,
                QuestionGroupID
                );
        }
    }
}