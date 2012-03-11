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

        public int UserID
        {
            get { return -1; }
        }

        public Data.User User
        {
            get { return null; }
        }

        public UserPermissions GetPermissions()
        {
            return null;
        }

        #endregion





    }
}