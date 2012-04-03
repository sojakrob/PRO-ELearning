using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;

namespace ELearning.Business.Reporting
{
    public class FormFillsDataReport
    {
        public Form Form { get; set; }

        public List<FormFillQuestionGroup> Groups { get; set; }
        public List<FormFillData> Fills { get; set; }



        /// <summary>
        /// Initializes a new instance of the FormFillsDataReport class.
        /// </summary>
        public FormFillsDataReport()
        {
            Groups = new List<FormFillQuestionGroup>();
            Fills = new List<FormFillData>();
        }
    }
}
