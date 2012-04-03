using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Managers;

namespace ELearning.Business.Reporting
{
    public class FormFillsDataReportCreator
    {
        private int _formID;
        private FormFillsDataReport _report;
        private FormManager _formManager;


        private FormFillsDataReportCreator(int formID, FormManager formManager)
        {
            _formID = formID;
            _formManager = formManager;

            _report = new FormFillsDataReport();
        }


        private FormFillsDataReport CreateReport()
        {
            var form = _formManager.GetForm(_formID);

            _report.Form = form;


            var questionGroups = form.QuestionGroups.OrderBy(g => g.Index);
            foreach (var questionGroup in questionGroups)
            {
                var group = new FormFillQuestionGroup();
                group.Questions = questionGroup.Questions.ToList();
                _report.Groups.Add(group);
            }

            foreach (var formInstance in _formManager.GetFormInstances(_formID))
            {
                var fill = new FormFillData();
                fill.Solver = formInstance.Solver;
                fill.Submited = formInstance.Submited;
                fill.Questions = formInstance.Questions;
                fill.Mark = formInstance.Evaluation.Mark.Name;

                _report.Fills.Add(fill);
            }

            return _report;
        }


        public static FormFillsDataReport CreateReport(int formID, FormManager formManager)
        {
            var creator = new FormFillsDataReportCreator(formID, formManager);
            creator.CreateReport();
            return creator._report;
        }

    }
}
