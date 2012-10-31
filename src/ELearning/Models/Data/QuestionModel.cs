using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Data
{
    public class QuestionModel : DataModelBase<Question>
    {
        private const int TEXT_MAX_LENGTH = 80;


        public int ID { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayLocalized("Text")]
        public string Text { get; set; }
        public string TextCropped
        {
            get { return Utils.Formatting.CropText(Text, TEXT_MAX_LENGTH); }
        }

        [DataType(DataType.MultilineText)]
        [DisplayLocalized("HelpText")]
        public string HelpText { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayLocalized("Explanation")]
        public string Explanation { get; set; }

        public int QuestionGroupID { get; set; }
        public int FormID { get; private set; }

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

            if (data.QuestionGroup != null)
                FormID = data.QuestionGroup.FormTemplateID;
        }


        public override Question ToData()
        {
            return QuestionManager.CreateNewQuestion(
                ID,
                Text,
                HelpText,
                Explanation,
                QuestionGroupID
                );
        }
    }
}