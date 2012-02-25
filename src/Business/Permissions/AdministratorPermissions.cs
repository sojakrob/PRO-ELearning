﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Business.Permissions
{
    public class AdministratorPermissions : LectorPermissions
    {
        public override bool User_CreateEdit
        {
            get
            {
                return true;
            }
        }
        public override bool User_Delete
        {
            get
            {
                return true;
            }
        }
        public override bool User_List
        {
            get
            {
                return true;
            }
        }

        public override bool Form_List
        {
            get
            {
                return true;
            }
        }
        public override bool Form_Delete
        {
            get
            {
                return true;
            }
        }
        public override bool Form_CreateEdit_All
        {
            get
            {
                return true;
            }
        }

        public override bool Question_CreateEdit_All
        {
            get
            {
                return true;
            }
        }


        internal AdministratorPermissions()
            : base()
        {
        }
    }
}
