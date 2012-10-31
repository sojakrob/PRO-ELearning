using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class StudentFormsModel : UserModel
    {
        public List<FormInstanceModel> FilledForms { get; private set; }


        public StudentFormsModel()
        {
            
        }
        public StudentFormsModel(User data, List<FormInstance> filledForms)
            : base(data)
        {
            if (filledForms != null)
            {
                FilledForms = new List<FormInstanceModel>();
                foreach (var filledForm in filledForms)
                    FilledForms.Add(new FormInstanceModel(filledForm));
            }
        }

    }
}