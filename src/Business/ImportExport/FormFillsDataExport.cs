﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Managers;
using System.IO;
using ELearning.Data;
using ELearning.Business.Reporting;
using ELearning.Business.Storages;
using ELearning.Business.Interfaces;

namespace ELearning.Business.ImportExport
{
    public class FormFillsDataExport
    {
        private const string CSV_DELIMITER = ",";
        private const string TEXT_QUOTE = "\"";

        private string _filename;
        private FormFillsDataReport _report;
        private TextWriter _writer;

        private ILocalization _localization;
        


        /// <summary>
        /// Initializes a new instance of the FormFillsDataExport class.
        /// </summary>
        private FormFillsDataExport(FormFillsDataReport report, System.Web.HttpServerUtilityBase server, ILocalization localization)
        {
            _report = report;
            _localization = localization;

            string path = LocalStorage.GetExportPath(server);
            _filename = string.Format("{0}{1}{2}.csv", path, DateTime.Now.ToFileTimeUtc(), _report.Form.Name);
        }


        private string ExportFormFillsReportToCsv()
        {
            _writer = new StreamWriter(_filename, false, Encoding.UTF8);

            WriteCsvHeader();
            WriteCsvData();

            _writer.Close();
            return _filename;
        }

        private void WriteCsvHeader()
        {
            _writer.Write(
                string.Format("{0}{1}{2}{1}", 
                    _localization.GetString("Solver"), 
                    CSV_DELIMITER, 
                    _localization.GetString("DateTime")
                    )
                );

            foreach (FormFillQuestionGroup group in _report.Groups)
            {
                foreach (Question question in group.Questions)
                {
                    WriteWithDelimiter(question.Text);
                }
            }

            WriteWithDelimiter(_localization.GetString("Mark"));
            _writer.WriteLine();
        }
        private void WriteCsvData()
        {
            foreach (var fill in _report.Fills)
            {
                WriteWithDelimiter(fill.Solver.Name);
                WriteWithDelimiter(fill.Submited);

                foreach (FormFillQuestionGroup group in _report.Groups)
                {
                    foreach (Question question in group.Questions)
                    {
                        var instance = fill.Questions.Where(q => q.QuestionID == question.ID).FirstOrDefault();
                        if (instance != null && instance.Answer != null)
                            Write(instance.Answer.ToString());
                        _writer.Write(CSV_DELIMITER);
                    }
                }

                WriteWithDelimiter(fill.Mark);

                _writer.WriteLine();
            }
        }

        private void Write(object value)
        {
            _writer.Write("{0}{1}{0}", TEXT_QUOTE, value);
        }
        private void WriteWithDelimiter(object value)
        {
            Write(value);
            _writer.Write(CSV_DELIMITER);
        }


        public static string ExportFormFillsReportToCsv(FormFillsDataReport report, System.Web.HttpServerUtilityBase server, ILocalization localization)
        {
            var exporter = new FormFillsDataExport(report, server, localization);
            return exporter.ExportFormFillsReportToCsv();
        }
    }
}
