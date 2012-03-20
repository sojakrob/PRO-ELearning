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
        public override bool Form_InfiniteInstances
        {
            get
            {
                return true;
            }
        }

        public override bool FormInstances_View
        {
            get
            {
                return true;
            }
        }

        public override bool Question_CreateEdit_Own
        {
            get
            {
                return true;
            }
        }


        internal LectorPermissions()
            : base()
        {
        }
    }
}
