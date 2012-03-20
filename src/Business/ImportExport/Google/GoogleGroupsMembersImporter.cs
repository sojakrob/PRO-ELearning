using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Managers;
using System.IO;
using ELearning.Data;

namespace ELearning.Business.ImportExport.Google
{
    public class GoogleGroupsMembersImporter
    {
        private const string CSV_SEPARATORS = ",;";
        private const int CSV_COLUMN_EMAIL = 0;
        private const int CSV_COLUMN_NAME = 1;


        private UserManager _userManager;
        private GroupManager _groupManager;


        /// <summary>
        /// Initializes a new instance of the GoogleGroupsMembersImporter class.
        /// </summary>
        public GoogleGroupsMembersImporter(UserManager userManager, GroupManager groupManager)
        {
            _userManager = userManager;
            _groupManager = groupManager;
        }


        public bool ImportCsv(int groupID, StreamReader reader)
        {
            ReadCsvHeader(reader);

            bool result = true;

            string line = reader.ReadLine();
            while (line != null)
            {
                bool imported = ImportCsvRecord(groupID, line);
                if(!imported)
                    result = false;

                line = reader.ReadLine();
            }

            return result;
        }

        private void ReadCsvHeader(StreamReader reader)
        {
            reader.ReadLine();
            reader.ReadLine();
        }
        private bool ImportCsvRecord(int groupID, string record)
        {
            string[] columns = record.Split(CSV_SEPARATORS.ToCharArray());
            string email = columns[CSV_COLUMN_EMAIL];
            string name = columns[CSV_COLUMN_NAME];
            name = name.Replace("\"", "");

            var user = _userManager.GetUser(email);
            if (user == null)
            {
                bool userCreated = _userManager.CreateUser(email, Data.Enums.UserTypes.Student);
                if (!userCreated)
                    return false;

                user = _userManager.GetUser(email);
            }

            bool assigned = _groupManager.AssignUser(user.ID, groupID);
            
            return assigned;
        }
    }
}
