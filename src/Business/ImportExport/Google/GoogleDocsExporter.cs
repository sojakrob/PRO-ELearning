using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Documents;
using Google.Documents;
using System.IO;
using System.Security.Authentication;


namespace ELearning.Business.ImportExport.Google
{
    public class GoogleDocsExporter
    {
        private const string APPLICATION_NAME = "ELearning";


        public bool UploadCsvSpreadsheet(string username, string password, string fileName)
        {
            if (!fileName.EndsWith(".csv"))
                throw new ApplicationException("Not a csv file");

            if (!File.Exists(fileName))
                throw new ApplicationException("File not exists");

            string documentName = Path.GetFileNameWithoutExtension(fileName);

            try
            {
                var service = new DocumentsService(APPLICATION_NAME);
                service.setUserCredentials(username, password);
                service.UploadDocument(fileName, documentName);
            }
            catch (AuthenticationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
