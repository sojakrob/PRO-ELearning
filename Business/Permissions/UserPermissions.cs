using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data.Enums;

namespace ELearning.Business.Permissions
{
    internal class UserPermissions
    {
        public virtual bool User_Create { get { return false; } }


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
