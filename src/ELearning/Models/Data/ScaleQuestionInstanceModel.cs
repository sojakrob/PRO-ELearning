using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class ScaleQuestionInstanceModel : QuestionInstanceModel
    {
        public int MinValue {get; private set; }
        public int MaxValue { get; private set; }
        public int Increment { get; private set; }


        public ScaleQuestionInstanceModel()
        {
            
        }
        public ScaleQuestionInstanceModel(QuestionInstance data)
            : base(data)
        {
            var scale = data.QuestionTemplate as ScaleQuestion;
            MinValue = scale.MinValue;
            MaxValue = scale.MaxValue;
            Increment = scale.Increment;
        }


        public override QuestionInstance ToData()
        {
            throw new NotImplementedException();
        }
    }
}