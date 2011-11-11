using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ELearning.Data.Enums;

namespace ELearning.Authentication
{
    public class ELearningMembershipUser : MembershipUser
    {
        public UserTypes Type { get; set; }


        public ELearningMembershipUser(string providerName, string name, object providerUserKey, string email, string passwordQuestion, string comment, bool isApproved, bool isLockedOut, DateTime creationDate, DateTime lastLoginDate, DateTime lastActivityDate, DateTime lastPasswordChangedDate, DateTime lastLockoutDate, UserTypes type)
            : base(providerName, name, providerUserKey, email, passwordQuestion, comment, isApproved, isLockedOut, creationDate, lastLoginDate, lastActivityDate, lastPasswordChangedDate, lastLockoutDate)
        {
            Type = type;
        }
        protected ELearningMembershipUser()
        {
            
        }
    }
}