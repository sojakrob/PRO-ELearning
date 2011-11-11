using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace ELearning.Authentication
{
    public class WebAuthenticationContext : IAuthenticationContext
    {
        public LoggedUser CurrentUser
        {
        	get {	return _currentUser; }
        	set { _currentUser = value;	}
        }
        private LoggedUser _currentUser;


        public void LogIn(string email, bool keepSignedIn)
        {
            FormsAuthentication.SetAuthCookie(email, keepSignedIn);

            if(System.Security.Principal.IPrincipal
            _currentUser = new LoggedUser(user);
        }
        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}
