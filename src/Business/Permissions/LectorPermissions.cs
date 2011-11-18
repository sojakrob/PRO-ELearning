using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Business.Permissions
{
    public class LectorPermissions : StudentPermissions
    {
        public override bool Form_CreateEdit
        {
            get
            {
                return true;
            }
        }
    }
}
