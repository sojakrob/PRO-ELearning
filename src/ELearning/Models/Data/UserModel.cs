using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Data
{
    public class UserModel : DataModelBase<User>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required] // TODO Add Regex check etc.
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserTypeModel Type { get; set; }


        /// <summary>
        /// Initializes a new instance of the UserModel class.
        /// </summary>
        public UserModel()
        {
            Name = string.Empty;
            Password = string.Empty;
        }
        public UserModel(User data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
            Email = data.Email;
            Password = string.Empty;

            if (data.Type == null)
                Type = new UserTypeModel();
            else
                Type = new UserTypeModel(data.Type);
        }


        public override User ToData()
        {
            return User.CreateUser(
                ID,
                Email,
                Type.ID
                );
        }
    }
}
