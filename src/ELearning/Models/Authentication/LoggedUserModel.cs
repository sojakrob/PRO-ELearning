using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data.Enums;
using ELearning.Business.Permissions;
using ELearning.Data;

namespace ELearning.Models.Authentication
{
    public class LoggedUserModel
    {
        public string Email { get; set; }
        public UserTypes Type { get; set; }
        public UserPermissions Permissions { get; set; }


        /// <summary>
        /// Initializes a new instance of the LoggedUserModel class.
        /// </summary>
        public LoggedUserModel()
        {

        }
        /// <summary>
        /// Initializes a new instance of the LoggedUserModel class.
        /// </summary>
        public LoggedUserModel(User data, UserPermissions permissions)
        {
            Email = data.Email;
            Type = data.TypeEnum;
            Permissions = permissions;
        }
    }
}