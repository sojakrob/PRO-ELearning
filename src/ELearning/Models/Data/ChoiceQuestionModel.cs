using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class ChoiceQuestionModel : QuestionModel
    {
        public bool Shuffle { get; set; }
        public List<ChoiceItemModel> ChoiceItems { get; set; }


        public ChoiceQuestionModel()
        {

        }
        public ChoiceQuestionModel(Question data)
            : base(data)
        {
            Shuffle = false;
            ChoiceItems = new List<ChoiceItemModel>();
        }
        public ChoiceQuestionModel(ChoiceQuestion data)
            : this(data as Question)
        {
            Shuffle = data.Shuffle;
            ChoiceItems = DataModelBase<ChoiceItem>.CreateFromArray<ChoiceItemModel>(data.ChoiceItems);
        }

        public override Question ToData()
        {
            var result = QuestionManager.CreateNewChoiceQuestion(
                            ID,
                            Text,
                            HelpText,
                            Explanation,
                            QuestionGroupID,
                            Shuffle
                            );

            result.ChoiceItems = new System.Data.Objects.DataClasses.EntityCollection<ChoiceItem>();
            foreach (ChoiceItemModel choiceItem in ChoiceItems)
                result.ChoiceItems.Add(choiceItem.ToData());	

            return result;
        }
    }
}
