using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Utils;

namespace ELearning.Models.Data
{
    public class FormInstanceModel : DataModelBase<FormInstance>
    {
        public int ID { get; set; }
        public DateTime Submited { get; set; }
        public FormModel FormTemplate { get; private set; }
        public bool IsPreview { get; private set; }
        public DateTime Created { get; private set; }
        public List<QuestionInstanceModel> Questions { get; set; }
        public FormInstanceEvaluationModel Evaluation { get; set; }

        public int? CurrentTimeToFill
        {
            get
            {
                if (FormTemplate.TimeToFill == null)
                    return null;
                TimeSpan elapsed = DateTime.Now.Subtract(Created);
                int result = Conversion.MinutesToSeconds(FormTemplate.TimeToFill.Value) - (int)elapsed.TotalSeconds;
                return result;
            }
        }


        public FormInstanceModel()
        {
            Questions = new List<QuestionInstanceModel>();
            Evaluation = new FormInstanceEvaluationModel();
        }
        public FormInstanceModel(FormInstance data)
            : base(data)
        {
            ID = data.ID;
            FormTemplate = new FormModel(data.FormTemplate);
            Questions = QuestionInstanceModelsConverter.CreateFromArray(data.Questions);
            Submited = data.Submited;
            IsPreview = data.IsPreview;
            Created = data.Created;
            //Solver = new UserModel(data.Solver);

            if (data.Evaluation != null)
                Evaluation = new FormInstanceEvaluationModel(data.Evaluation);
        }


        public override FormInstance ToData()
        {
            throw new NotImplementedException();
        }
    }
}
