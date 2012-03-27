using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Managers;
using System.IO;
using ELearning.Data;

namespace ELearning.Business.ImportExport
{
    public class FormFillsDataExport
    {
        private const string CSV_DELIMITER = ",";
        private FormManager _formManager;


        /// <summary>
        /// Initializes a new instance of the FormFillsDataExport class.
        /// </summary>
        public FormFillsDataExport(FormManager formManager)
        {
            _formManager = formManager;
        }


        public bool ExportFormFillsToCsv(int formID, string fileName)
        {
            TextWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);

            var form = _formManager.GetForm(formID);

            // Header
            writer.Write(string.Format("Solver{0}DateTime{0}", CSV_DELIMITER));

            Dictionary<int, QuestionGroup> questionGroups = new Dictionary<int,QuestionGroup>();
            foreach(var questionGroup in form.QuestionGroups)
                questionGroups.Add(questionGroup.Index, questionGroup);
            int inc = 0;
            for (int i = 0; i < questionGroups.Count; i++)
            {
                while (!questionGroups.ContainsKey(i + inc))
                    inc++;

                writer.Write(questionGroups[i+inc].Questions.First().Text);
                writer.Write(CSV_DELIMITER);
            }
            writer.WriteLine();
            
            // Data
            foreach (var instance in _formManager.GetFormInstances(formID))
            {
                writer.Write(instance.Solver.Name);
                writer.Write(CSV_DELIMITER);

                writer.Write(instance.Submited);
                writer.Write(CSV_DELIMITER);

                Dictionary<int, QuestionInstance> questions = new Dictionary<int, QuestionInstance>();
                foreach (var question in instance.Questions)
                    questions.Add(question.QuestionTemplate.QuestionGroup.Index, question);

                inc = 0;
                for (int i = 0; i < questions.Count; i++)
                {
                    while (!questions.ContainsKey(i + inc))
                        inc++;

                    writer.Write(questions[i+inc].Answer != null ? questions[i+inc].Answer.ID.ToString() : string.Empty);
                    writer.Write(CSV_DELIMITER);
                }
                writer.WriteLine();
            }

            writer.Close();
            return true;
        }
    }
}
