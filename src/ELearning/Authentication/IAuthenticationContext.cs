using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace ELearning.Authentication
{
    public interface IAuthenticationContext
    {
        UserSession LoggedUserSession { get; }
        bool IsUserLoggedIn { get; }

        bool LogIn(string email, string password, bool keepSignedIn);
        void LogOff();
    }
}
