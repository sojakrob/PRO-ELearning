using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Business.Permissions;

namespace ELearning.Authentication
{
    public class AnonymousPermissionsProvider : IPermissionsProvider
    {
        #region IPermissionsProvider Members

        public UserPermissions GetPermissions()
        {
            return null;
        }

        #endregion
    }
}