using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using System.Data.Objects.DataClasses;
using ELearning.Models.Controls;

namespace ELearning.Models.Data
{
    public class ScaleQuestionModel : QuestionModel
    {
        public UpDownControlModel MinValue { get; private set; }
        public UpDownControlModel MaxValue { get; private set; }
        public UpDownControlModel Increment { get; private set; }



        
        public ScaleQuestionModel()
        {
            CreateUpDownControllers(1, 5, 1);
        }
        public ScaleQuestionModel(Question data, int min, int max, int increment)
            : base(data)
        {
            CreateUpDownControllers(min, max, increment);
        }
        public ScaleQuestionModel(Question data)
            : this(data, 1, 5, 1)
        {
        }
        public ScaleQuestionModel(ScaleQuestion data)
            : this(data as Question, data.MinValue, data.MaxValue, data.Increment)
        {
        }


        private void CreateUpDownControllers(int min, int max, int inc)
        {
            MinValue = new UpDownControlModel("MinValue", min, Localization.GetResourceString("LowerBound"));
            MaxValue = new UpDownControlModel("MaxValue", max, Localization.GetResourceString("UpperBound"));
            Increment = new UpDownControlModel("Increment", inc, Localization.GetResourceString("StepSize"));
        }


        public override Question ToData()
        {
            var result = QuestionManager.CreateNewScaleQuestion(
                ID,
                Text,
                HelpText,
                Explanation,
                QuestionGroupID,
                MinValue.Value,
                MaxValue.Value,
                Increment.Value
                );
            return result;
        }
    }
}
