using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace ELearning.Authentication
{
    public class WebAuthenticationContext : IAuthenticationContext
    {

        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}
