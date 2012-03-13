using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using ELearning.Data;

namespace ELearning.Authentication
{
    public class WebAuthenticationContext : IAuthenticationContext
    {
        private const string USER_SESSION = "CA7194F21EE3";


        /// <summary>
        /// Gets the logged user
        /// </summary>
        public UserSession LoggedUserSession
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;

                if (HttpContext.Current.Session[USER_SESSION] == null && Membership.GetUser() != null)
                    LoggedUserSession = CreateUserSession(Membership.GetUser().UserName);
                
                return (HttpContext.Current.Session[USER_SESSION] as UserSession);
            }
            private set
            {
                if (HttpContext.Current == null)
                    return;

                HttpContext.Current.Session[USER_SESSION] = value;
            }
        }

        public bool IsUserLoggedIn
        {
            get { return LoggedUserSession != null; }
        }


        public bool LogIn(string email, string password, bool keepSignedIn)
        {
            bool loginResult = Membership.ValidateUser(email, password);
            if (!loginResult)
                return false;

            FormsAuthentication.SetAuthCookie(email, keepSignedIn);

            LoggedUserSession = CreateUserSession(email);

            return true;
        }
        public void LogOff()
        {
            FormsAuthentication.SignOut();

            LoggedUserSession = null;
        }


        private static UserSession CreateUserSession(string email)
        {
            return new UserSession(((ELearningMembershipUser)Membership.GetUser(email)).User);
        }

        #region IPermissionsProvider Members

        public int UserID
        {
            get 
            {
                if (LoggedUserSession == null)
                    return -1;

                return LoggedUserSession.User.ID;
            }
        }

        public User User
        {
            get
            {
                if (LoggedUserSession == null)
                    return null;
                return ((ELearningMembershipUser)Membership.GetUser(LoggedUserSession.User.Email)).User;
            }
        }

        public Business.Permissions.UserPermissions GetPermissions()
        {
            if (LoggedUserSession == null)
                return null;

            return LoggedUserSession.Permissions;
        }

        #endregion
    }
}
