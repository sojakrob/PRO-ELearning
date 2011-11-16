using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Data.Enums;
using ELearning.Business.Permissions;
using System.Web.Security;

namespace ELearning.Authentication
{
    public class UserSession
    {
        public string Email { get { return User.Email; } }
        public UserTypes Type { get { return User.TypeEnum; } }

        public User User { get { return _user; } }
        private User _user;

        public UserPermissions Permissions { get { return _permissions; } }
        private UserPermissions _permissions;


        /// <summary>
        /// Initializes a new instance of the UserSession class.
        /// </summary>
        public UserSession(User user)
        {
            _user = user;
            _permissions = ((ELearningMembershipUser)Membership.GetUser(user.Email)).Permissions;
        }

        
    }
}
