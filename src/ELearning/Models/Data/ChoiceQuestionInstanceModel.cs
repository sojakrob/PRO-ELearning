using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class ChoiceQuestionInstanceModel : QuestionInstanceModel
    {
        public bool Shuffle { get; private set; }
        public List<ChoiceItemModel> ChoiceItems { get; private set; }


        public ChoiceQuestionInstanceModel()
        {
            
        }
        public ChoiceQuestionInstanceModel(QuestionInstance data)
            : base(data)
        {
            var choice = data.QuestionTemplate as ChoiceQuestion;
            Shuffle = choice.Shuffle;
            ChoiceItems = DataModelBase<ChoiceItem>.CreateFromArray<ChoiceItemModel>(choice.ChoiceItems);
        }


        public override QuestionInstance ToData()
        {
            throw new NotImplementedException();
        }
    }
}