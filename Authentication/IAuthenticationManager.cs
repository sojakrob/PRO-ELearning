using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace ELearning.Authentication
{
    public interface IAuthenticationContext
    {
        void LogOff();
    }
}
