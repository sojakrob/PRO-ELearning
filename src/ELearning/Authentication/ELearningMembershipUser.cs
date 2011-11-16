using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ELearning.Data.Enums;
using ELearning.Business.Permissions;
using ELearning.Data;

namespace ELearning.Authentication
{
    public class ELearningMembershipUser : MembershipUser
    {
        public User User { get; private set; }
        public UserTypes Type { get; set; }
        public UserPermissions Permissions { get; set; }


        public ELearningMembershipUser(
            string providerName, 
            string name, 
            object providerUserKey, 
            string email, 
            string passwordQuestion, 
            string comment, 
            bool isApproved, 
            bool isLockedOut, 
            DateTime creationDate, 
            DateTime lastLoginDate, 
            DateTime lastActivityDate, 
            DateTime lastPasswordChangedDate, 
            DateTime lastLockoutDate, 
            User user,
            UserTypes type, 
            UserPermissions permissions
            ) : base(
                providerName, 
                name, 
                providerUserKey, 
                email, 
                passwordQuestion, 
                comment, 
                isApproved, 
                isLockedOut, 
                creationDate, 
                lastLoginDate, 
                lastActivityDate, 
                lastPasswordChangedDate, 
                lastLockoutDate
            )
        {
            User = user;
            Type = type;
            Permissions = permissions;
        }
        protected ELearningMembershipUser()
        {
            
        }
    }
}