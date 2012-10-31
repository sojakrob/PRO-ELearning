using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;
using System.ComponentModel.DataAnnotations;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class NewUserModel : UserModel
    {
        [Required]
        public string Password { get; set; }


        public NewUserModel()
            : base()
        {
            Password = string.Empty;
        }
        public NewUserModel(User data)
            : base(data)
        {
            Password = string.Empty;
        }


        public override User ToData()
        {
            return UserManager.GetNewUserInstance(
                ID,
                Email,
                Type.ID,
                Password,
                true
                );
        }
    }
}
