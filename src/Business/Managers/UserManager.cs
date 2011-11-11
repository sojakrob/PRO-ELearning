using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Permissions;
using ELearning.Business.Exceptions;
using ELearning.Data.Enums;

namespace ELearning.Business.Managers
{
    public class UserManager : ManagerBase<User>
    {
        /// <summary>
        /// Initializes a new instance of the UserManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public UserManager(IPersistentStorage persistentStorage)
            : base(persistentStorage)
        {
            
        }


        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="authorEmail"></param>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <param name="type">User type</param>
        /// <returns></returns>
        public bool CreateUser(string authorEmail, string email, string password, UserTypes type)
        {
            UserPermissions perms = GetUserPermissions(authorEmail);
            if (!perms.User_Create)
                throw new PermissionException("User_Create");

            try
            {
                User user = User.CreateUser(0, email, GetUserTypeID(type));

                Context.User.AddObject(user);
                Context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets user by specified email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        public User GetUser(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new ArgumentException("Email is null or empty.", "email");
          
            return GetSingle(u => u.Email == email);
        }

        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            return false;
        }
        /// <summary>
        /// Gets if password fits to specified user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateUser(string email, string password)
        {
            User user = GetUser(email);
            return email == password;
        }


        /// <summary>
        /// Gets user's permissions
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns></returns>
        private UserPermissions GetUserPermissions(string email)
        {
            User user = GetUser(email);
            if(user == null)
                throw new ArgumentException("User not found", "email");

            return GetUserPermissions(user);
        }
        /// <summary>
        /// Gets user's permissions
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private UserPermissions GetUserPermissions(User user)
        {
            return UserPermissions.Get(user.TypeEnum);
        }


        private int GetUserTypeID(UserTypes type)
        {
            return Context.UserType.Single(t => t.Name == type.ToString()).ID;
        }
    }
}
