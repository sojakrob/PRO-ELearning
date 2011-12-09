using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class QuestionInstanceModel : DataModelBase<QuestionInstance>
    {
        public int ID { get; private set; }
        public int FormID { get; private set; }
        public string Text { get; private set; }
        public string HelpText { get; private set; }
        public int Index { get; private set; }
        public QuestionGroupModel TemplateGroup { get; private set; }

        
        public QuestionInstanceModel()
        {
            
        }
        public QuestionInstanceModel(QuestionInstance data)
            : base(data)
        {
            ID = data.ID;
            FormID = data.FormInstanceID;
            Text = data.QuestionTemplate.Text;
            HelpText = data.QuestionTemplate.HelpText;
            Index = data.QuestionTemplate.QuestionGroup.Index;
            TemplateGroup = new QuestionGroupModel(data.QuestionTemplate.QuestionGroup);
        }
        

        public override QuestionInstance ToData()
        {
            return QuestionManager.CreateNewQuestionInstance(
                Index,
                ID,
                FormID
                );
        }
    }
}