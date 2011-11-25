using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data.Enums;

namespace ELearning.Business.Permissions
{
    public class UserPermissions
    {
        /// <summary>
        /// Can create User
        /// </summary>
        public virtual bool User_CreateEdit 
        { 
            get 
            { 
                return false; 
            } 
        }
        public virtual bool User_Delete
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Can view list of Users
        /// </summary>
        public virtual bool User_List { get { return false; } }

        public virtual bool Form_List
        {
            get { return false; }
        }
        public virtual bool Form_CreateEdit
        {
            get { return false; }
        }
        public virtual bool Form_CreateEdit_All
        {
            get
            {
                return false;
            }
        }
        public virtual bool Form_Delete
        {
            get { return false; }
        }

        public virtual bool Question_CreateEdit_Own
        {
            get { return false; }
        }
        public virtual bool Question_CreateEdit_All
        {
            get { return false; }
        }


        public static UserPermissions Get(UserTypes userType)
        {
            switch (userType)
            {
                case UserTypes.Student:
                    return new StudentPermissions();

                case UserTypes.Lector:
                    return new LectorPermissions();

                case UserTypes.Administrator:
                    return new AdministratorPermissions();

                default:
                    throw new NotImplementedException("UserType not implemented");
            }
        }
    }
}
