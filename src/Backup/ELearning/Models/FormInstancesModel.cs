using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Models.Data;

namespace ELearning.Models
{
    public class FormInstancesModel
    {
        public FormModel Form { get; set; }
        public ICollection<FormInstanceModel> FormInstances { get; set; }


        /// <summary>
        /// Initializes a new instance of the FormInstancesModel class.
        /// </summary>
        public FormInstancesModel(FormModel form, ICollection<FormInstanceModel> formInstances)
        {
            Form = form;
            FormInstances = formInstances;
        }
    }
}