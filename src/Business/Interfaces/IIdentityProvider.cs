using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Permissions;

namespace ELearning.Business.Interfaces
{
    public interface IIdentityProvider
    {
        int UserID { get; }
        User User { get; }
        UserPermissions GetPermissions();
    }
}
