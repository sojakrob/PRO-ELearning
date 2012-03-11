using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class FormInstanceEvaluationModel : DataModelBase<FormInstanceEvaluation>
    {
        public int ID { get; set; }
        public MarkValueModel Mark { get; set; }
        public string Note { get; set; }

        
        public FormInstanceEvaluationModel()
        {
            Note = string.Empty;
        }
        public FormInstanceEvaluationModel(FormInstanceEvaluation data)
            : base(data)
        {
            ID = data.ID;
            Note = data.Note;

            if (data.Mark != null)
                Mark = new MarkValueModel(data.Mark);
        }


        public override FormInstanceEvaluation ToData()
        {
            var result = FormManager.CreateNewFormEvaluation();
            result.Note = Note == null ? string.Empty : Note;

            if (Mark == null || Mark.IsNull)
                result.MarkValueID = null;
            else
                result.MarkValueID = Mark.ID;

            return result;
        }
    }
}