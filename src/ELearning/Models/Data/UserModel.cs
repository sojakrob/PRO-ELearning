using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;

namespace ELearning.Models.Data
{
    public class UserModel : DataModelBase<User>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserTypes Type { get; set; }


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
            Name = data.Name;
            Email = data.Email;
            Type = data.TypeEnum;
        }


        public override User ToData()
        {
            throw new NotImplementedException();
        }
    }
}
