using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;

namespace ELearning.Business.Permissions
{
    public interface IPermissionsProvider
    {
        int UserID { get; }
        User User { get; }
        UserPermissions GetPermissions();
    }
}
