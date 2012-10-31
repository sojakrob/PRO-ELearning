using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Data
{
    public class TextBookLinkModel : DataModelBase<TextBookLink>
    {
        private System.Data.Objects.DataClasses.EntityCollection<TextBookLink> entityCollection;

        public TextBookLinkModel(System.Data.Objects.DataClasses.EntityCollection<TextBookLink> entityCollection)
        {
            // TODO: Complete member initialization
            this.entityCollection = entityCollection;
        }
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayLocalized("Header")]
        public string HName { get; set; }
        public TextBookModel TextBook { get; set; }
        public QuestionModel Question { get; set; }

        public override TextBookLink ToData()
        {
            return TextBookLinkManager.CreateTextBookQuestionLink(TextBook.ID, Question.ID, HName);
        }

    }
}