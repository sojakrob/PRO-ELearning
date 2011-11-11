using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data.Enums;
using ELearning.Shared;

namespace ELearning.Data
{
    public partial class User
    {
        /// <summary>
        /// Gets User name extracted from Email address
        /// </summary>
        public string Name
        {
            get { return NameFromEmail(Email); }
        }

        public UserTypes TypeEnum
        {
            get  { return EnumUtility.EnumFromName<Enums.UserTypes>(Type.Name); }
        }


        private static string NameFromEmail(string email)
        {
            return email.Substring(0, email.IndexOf('@'));
        }         
    }
}
