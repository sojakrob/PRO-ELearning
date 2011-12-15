using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Models.Data;
using ELearning.Data;

namespace ELearning.Models
{
    public class FormInstanceFillModel : FormInstanceModel
    {
        public UserModel Solver { get; private set; }


        public FormInstanceFillModel()
        {
            
        }
        public FormInstanceFillModel(FormInstance data)
            : base(data)
        {
            Solver = new UserModel(data.Solver);
        }
    }
}