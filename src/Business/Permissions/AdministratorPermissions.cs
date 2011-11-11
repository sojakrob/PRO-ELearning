using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Business.Permissions
{
    internal class AdministratorPermissions : LectorPermissions
    {
        public override bool User_Create
        {
            get
            {
                return true;
            }
        }
    }
}
