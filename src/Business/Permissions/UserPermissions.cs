﻿using System;
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
        /// <summary>
        /// Can view list of Groups
        /// </summary>
        public virtual bool Group_List_All { get { return false; } }
        public virtual bool Group_CreateEdit { get { return false; } }
        public virtual bool Group_Delete { get { return false; } }

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
        public virtual bool Form_InfiniteInstances
        {
            get
            {
                return false;
            }
        }

        public virtual bool TextBook_List
        {
            get { return false; }
        }
        public virtual bool TextBook_CreateEdit
        {
            get
            {
                return false;
            }
        }
        public virtual bool TextBook_CreateEdit_All { get { return false; } }
        public virtual bool TextBook_Delete { get { return false; } }


        public virtual bool FormInstances_View
        {
            get
            {
                return false;
            }
        }

        public virtual bool Question_CreateEdit_Own
        {
            get { return false; }
        }
        public virtual bool Question_CreateEdit_All
        {
            get { return false; }
        }


        internal UserPermissions()
        {
        }


        internal static UserPermissions Get(UserTypes userType)
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
