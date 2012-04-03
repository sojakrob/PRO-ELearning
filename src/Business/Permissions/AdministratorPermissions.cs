using System;
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

        public override bool Group_List_All
        {
            get
            {
                return true;
            }
        }
        public override bool Group_CreateEdit
        {
            get
            {
                return true;
            }
        }
        public override bool Group_Delete
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

        public override bool TextBook_List
        {
            get
            {
                return true;
            }
        }
        public override bool TextBook_CreateEdit_All
        {
            get
            {
                return true;
            }
        }
        public override bool TextBook_Delete
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
