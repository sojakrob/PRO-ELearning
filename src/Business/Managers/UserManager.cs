using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Permissions;
using ELearning.Business.Exceptions;
using ELearning.Data.Enums;
using System.Security.Cryptography;
using System.IO;

namespace ELearning.Business.Managers
{
    public class UserManager : ManagerBase<User>
    {
        public int DefaultUserTypeID
        {
            get
            {
                return 3;
                // TODO Get from settings
            }
        }


        /// <summary>
        /// Initializes a new instance of the UserManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public UserManager(IPersistentStorage persistentStorage)
            : base(persistentStorage)
        {
            
        }


        public override IQueryable<User> GetAll()
        {
            return Context.User.Where(u => u.IsActive == true);
        }

        public bool CreateUser(string authorEmail, string email, string password, int typeID)
        {
            if (!GetUserPermissions(authorEmail).User_CreateEdit)
                throw new PermissionException("User_CreateEdit");

            if (GetUser(email) != null)
                return false;

            try
            {
                User user = GetNewUserInstance(0, email, typeID, password, true);

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
        /// Creates new user
        /// </summary>
        /// <param name="authorEmail"></param>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <param name="type">User type</param>
        /// <returns></returns>
        public bool CreateUser(string authorEmail, string email, string password, UserTypes type)
        {
            return CreateUser(authorEmail, email, password, GetUserTypeID(type));
        }

        /// <summary>
        /// Deletes specified user (in fact only deactivates the user because of his created forms etc.)
        /// </summary>
        /// <param name="authorEmail"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool DeleteUser(string authorEmail, string email)
        {
            UserPermissions perms = GetUserPermissions(authorEmail);
            if (!perms.User_Delete)
                throw new PermissionException("User_Delete");

            User user = GetUser(email);
            if (user == null)
                return false;

            try
            {
                user.IsActive = false;

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
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
          
            return GetSingle(u => u.Email == email && u.IsActive == true);
        }

        public bool ChangePassword(string authorEmail, string email, string oldPassword, string newPassword)
        {
            bool isChangingOwnEmail = (authorEmail == email);
            if (!isChangingOwnEmail)
                if (!GetUserPermissions(authorEmail).User_CreateEdit)
                    throw new PermissionException("User_CreateEdit");

            User user = GetUser(email);
            if (user == null)
                return false;

            if (user.Password != Security.GetPasswordHash(oldPassword))
                return false;

            user.Password = Security.GetPasswordHash(newPassword);

            Context.SaveChanges();

            return true;
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
            return user.Password == Security.GetPasswordHash(password);
        }


        /// <summary>
        /// Gets user's permissions
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns></returns>
        public UserPermissions GetUserPermissions(string email)
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

        public IQueryable<UserType> GetUserTypes()
        {
            return Context.UserType;
        }


        private int GetUserTypeID(UserTypes type)
        {
            string sType = type.ToString();
            return Context.UserType.Single(t => t.Name == sType).ID;
        }


        public static User GetNewUserInstance(int ID, string email, int userTypeID, string password, bool isActive)
        {
            return User.CreateUser(
                ID,
                email,
                userTypeID,
                Security.GetPasswordHash(password),
                isActive
                );
        }

    }
}
