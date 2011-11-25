using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class QuestionGroupModel : DataModelBase<QuestionGroup>
    {
        public int ID { get; set; }
        public int FormTemplateID { get; set; }
        public int Index { get; set; }
        public QuestionGroupTypeModel Type { get; set; }
        public List<QuestionModel> Questions { get; set; }

        public Question NewQuestion { get; set; }


        public QuestionGroupModel()
        {
            
        }
        public QuestionGroupModel(QuestionGroup data)
            : base(data)
        {
            ID = data.ID;
            FormTemplateID = data.FormTemplateID;
            Index = data.Index;
            Type = new QuestionGroupTypeModel(data.Type);
            Questions = DataModelBase<Question>.CreateFromArray<QuestionModel>(data.Questions);
        }


        public override QuestionGroup ToData()
        {
            return QuestionManager.CreateNewQuestionGroupInstance(
                ID,
                Index,
                Type.ID,
                FormTemplateID
                );
        }
    }
}