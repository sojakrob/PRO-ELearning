using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class QuestionGroupModel : DataModelBase<QuestionGroup>
    {
        public int ID { get; set; }
        public QuestionGroupTypeModel Type { get; set; }
        public List<QuestionModel> Questions { get; set; }


        public QuestionGroupModel()
        {
            
        }
        public QuestionGroupModel(QuestionGroup data)
            : base(data)
        {
            ID = data.ID;
            Type = new QuestionGroupTypeModel(data.Type);
            Questions = DataModelBase<Question>.CreateFromArray<QuestionModel>(data.Questions);
        }


        public override QuestionGroup ToData()
        {
            throw new NotImplementedException();
        }
    }
}