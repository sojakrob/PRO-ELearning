using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace ELearning.Authentication
{
    public interface IAuthenticationContext
    {
        LoggedUser CurrentUser { get; }

        void LogIn(string email, bool keepSignedIn);
        void LogOff();
    }
}
