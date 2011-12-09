using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class ChoiceItemModel : DataModelBase<ChoiceItem>
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public bool IsCorrect { get; set; }
        public string Explanation { get; set; }
        public int QuestionID { get; private set; }


        public ChoiceItemModel()
        {
            
        }
        public ChoiceItemModel(ChoiceItem data)
            : base(data)
        {
            ID = data.ID;
            Text = data.Text;
            Index = data.Index;
            IsCorrect = data.IsCorrect;
            QuestionID = data.ChoiceQuestionID;
            Explanation = data.Explanation;
        }


        public override ChoiceItem ToData()
        {
            return QuestionManager.CreateNewChoiceItem(
                ID,
                QuestionID,
                Text,
                Index,
                IsCorrect
                );
        }
    }
}
