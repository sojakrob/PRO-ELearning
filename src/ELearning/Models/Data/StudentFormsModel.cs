using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class StudentFormsModel : StudentModel
    {
        public IEnumerable<FormInstancesModel> FormsFilled { get; private set; }


        public StudentFormsModel()
        {
            
        }
        public StudentFormsModel(User data)
            : base(data)
        {
            
        }

    }
}