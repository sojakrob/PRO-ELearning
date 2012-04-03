using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Business.Permissions
{
    public class StudentPermissions : UserPermissions
    {
        public override bool TextBook_CreateEdit
        {
            get
            {
                return true;
            }
        }


        internal StudentPermissions()
            : base()
        {
        }
    }
}
