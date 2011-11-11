using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data.Enums;
using ELearning.Business.Permissions;

namespace ELearning.Models.Authentication
{
    public class LoggedUserModel
    {
        public string Email { get; set; }
        public UserTypes Type { get; set; }
        public UserPermissions Permissions { get; set; }
    }
}