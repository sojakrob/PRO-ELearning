using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Models.Data;

namespace ELearning.Models
{
    public class FormFillsModel : Data.FormModel
    {
        public IEnumerable<FormInstanceFillModel> FormInstances { get; private set; }


        /// <summary>
        /// Initializes a new instance of the FormFillsModel class.
        /// </summary>
        /// <param name="form"></param>
        public FormFillsModel()
        {
            
        }
        public FormFillsModel(Form data)
            : base(data)
        {
            FormInstances = DataModelBase<FormInstance>.CreateFromArray<FormInstanceFillModel>(data.FormInstances.Where(f => !f.IsPreview));
        }
        


    }
}