using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Documents;
using Google.Documents;
using System.IO;
using System.Security.Authentication;
using ELearning.Business.Reporting;
using Google.GData.Client;
using ELearning.Business.Interfaces;


namespace ELearning.Business.ImportExport.Google
{
    public static class GoogleDocsExporter
    {
        private const string APPLICATION_NAME = "ELearning";


        public static bool UploadCsvSpreadsheet(string username, string password, string documentName, string fileName)
        {
            if (!fileName.EndsWith(".csv"))
                throw new ApplicationException("Not a csv file");

            if (!File.Exists(fileName))
                throw new ApplicationException("File not exists");

            if (string.IsNullOrEmpty(documentName))
                throw new ApplicationException("DocumentName cannot be empty");

            documentName = documentName.Replace('.', '/');

            try
            {
                var service = new DocumentsService(APPLICATION_NAME);
                service.setUserCredentials(username, password);
                service.UploadDocument(fileName, documentName);
            }
            catch (InvalidCredentialsException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool UploadReport(
            FormFillsDataReport report, 
            string documentName, 
            string username, 
            string password, 
            System.Web.HttpServerUtilityBase server, 
            ILocalization localization
            )
        {
            string filename = FormFillsDataExport.ExportFormFillsReportToCsv(report, server, localization);
            if (filename == null)
                return false;

            bool result = UploadCsvSpreadsheet(username, password, documentName, filename);

            File.Delete(filename);

            return result;
        }
    }
}
