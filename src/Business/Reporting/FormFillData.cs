using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using System.Data.Objects.DataClasses;

namespace ELearning.Business.Reporting
{
    public class FormFillData
    {
        public User Solver { get; set; }
        public DateTime Submited { get; set; }
        public string Mark { get; set; }

        public EntityCollection<QuestionInstance> Questions { get; set; }


        public FormFillData()
        {

        }
    }
}
