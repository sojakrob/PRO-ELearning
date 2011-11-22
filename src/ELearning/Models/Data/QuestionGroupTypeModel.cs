using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;

namespace ELearning.Models.Data
{
    public class QuestionGroupTypeModel : DataModelBase<QuestionGroupType>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public QuestionTypes Enum { get; set; }


        public QuestionGroupTypeModel()
        {
            
        }
        public QuestionGroupTypeModel(QuestionGroupType data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
            Enum = Shared.EnumUtility.EnumFromName<QuestionTypes>(Name);
        }


        public override QuestionGroupType ToData()
        {
            return QuestionGroupType.CreateQuestionGroupType(ID, Name);
        }
    }
}