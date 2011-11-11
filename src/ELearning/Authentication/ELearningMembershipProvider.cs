using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Configuration;
using System.Web.Configuration;
using ELearning.Business.Managers;
using ELearning.Business.Storages;
using Microsoft.Practices.Unity;
using ELearning.Data.Enums;


namespace ELearning.Authentication
{
    public class ELearningMembershipProvider : MembershipProvider
    {
        private const string MEMBERSHIP_SECTION_NAME = "system.web/membership";
        private const string APPLICATION_NAME_PARAMETER = "applicationName";


        private UserManager _userManager = MvcApplication.UnityContainer.Resolve<UserManager>() as UserManager;


        private ProviderSettings ConfigSettings
        {
            get
            {
                if (_configSettings == null)
                {
                    MembershipSection membershipSection = WebConfigurationManager.GetSection(MEMBERSHIP_SECTION_NAME) as MembershipSection;
                    _configSettings = membershipSection.Providers[membershipSection.DefaultProvider];
                }
                return _configSettings;
            }
        }
        private ProviderSettings _configSettings;
                                                 

        public override string ApplicationName
        {
            get
            {
                return ConfigSettings.Parameters[APPLICATION_NAME_PARAMETER];
            }
            set
            {
                ;
            }
        }
        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }
        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }
        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }
        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }
        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }
        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }
        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }
        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }
        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }


        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }
        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            return _userManager.ValidateUser(username, password);
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }


        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return _userManager.ChangePassword(username, oldPassword, newPassword);
        }
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }
        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }


        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return new ELearningMembershipUser("ELearningMembershipProvider", username, 1, username, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, UserTypes.Administrator);
        }
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        public override string GetUserNameByEmail(string email)
        {
            return _userManager.GetUser(email).Name;
        }
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }
    }
}
