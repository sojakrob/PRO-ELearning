using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class FormInstanceModel : DataModelBase<FormInstance>
    {
        public int ID { get; set; }
        public DateTime Submited { get; set; }
        public FormModel FormTemplate { get; private set; }
        public List<QuestionInstanceModel> Questions { get; set; }       


        public FormInstanceModel()
        {
            
        }
        public FormInstanceModel(FormInstance data)
            : base(data)
        {
            ID = data.ID;
            FormTemplate = new FormModel(data.FormTemplate);
            Questions = QuestionInstanceModelsConverter.CreateFromArray(data.Questions);
            Submited = data.Submited;
        }


        public override FormInstance ToData()
        {
            throw new NotImplementedException();
        }
    }
}
