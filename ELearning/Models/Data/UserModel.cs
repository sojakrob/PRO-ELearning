using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class UserModel : DataModelBase<User>
    {
        public int ID { get; set; }
        public string Name { get; set; }


        /// <summary>
        /// Initializes a new instance of the UserModel class.
        /// </summary>
        public UserModel()
        {
            
        }
        public UserModel(User data)
            : base(data)
        {
            ID = data.ID;
            Name = NameFromEmail(data.Email);
        }


        public override User ToData()
        {
            throw new NotImplementedException();
        }


        private static string NameFromEmail(string email)
        {
            return email.Substring(0, email.IndexOf('@'));
        }         
    }
}
