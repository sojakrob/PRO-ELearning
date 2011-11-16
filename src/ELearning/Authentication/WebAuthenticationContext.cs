using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;

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

            LoggedUserSession = new UserSession(((ELearningMembershipUser)Membership.GetUser(email)).User);

            return true;
        }
        public void LogOff()
        {
            FormsAuthentication.SignOut();

            LoggedUserSession = null;
        }
    }
}
