using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Business.Permissions
{
    public interface IPermissionsProvider
    {
        UserPermissions GetPermissions();
    }
}
