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
        public virtual bool User_Create 
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
