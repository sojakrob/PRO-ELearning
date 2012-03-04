using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using ELearning.Business.Permissions;

namespace ELearning.Authentication
{
    public interface IAuthenticationContext : IPermissionsProvider
    {
        UserSession LoggedUserSession { get; }
        bool IsUserLoggedIn { get; }

        bool LogIn(string email, string password, bool keepSignedIn);
        void LogOff();
    }
}
