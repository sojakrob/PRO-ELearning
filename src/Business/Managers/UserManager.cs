﻿using System;
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
        public const string DEF_PASSWORD = "Pass123";

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
        public UserManager(IPersistentStorage persistentStorage, ManagersContainer container, ELearning.Business.Interfaces.IIdentityProvider permissionsProvider)
            : base(persistentStorage, container, permissionsProvider)
        {
            
        }


        public override IQueryable<User> GetAll()
        {
            return Context.User.Where(u => u.IsActive == true);
        }

        public bool UserExists(string email)
        {
            return GetUser(email) != null;
        }

        public bool CreateUser(string email, UserTypes type)
        {
            return CreateUser(email, email, type);
        }
        public bool CreateUser(string email, string password, int typeID)
        {
            if (!Permissions.User_CreateEdit)
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
        public bool CreateUser(string email, string password, UserTypes type)
        {
            return CreateUser(email, password, GetUserTypeID(type));
        }

        /// <summary>
        /// Deletes specified user (in fact only deactivates the user because of his created forms etc.)
        /// </summary>
        /// <param name="authorEmail"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool DeleteUser(string email)
        {
            UserPermissions perms = Permissions;
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

            // TODO Implement caching
            return GetSingle(u => u.Email == email && u.IsActive == true);
        }
        public User GetUser(int userID)
        {
            return Context.User.Where(u => u.ID == userID).FirstOrDefault();
        }

        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            bool isChangingOwnEmail = (IdentityProvider.User.Email == email);
            if (!isChangingOwnEmail)
                if (!Permissions.User_CreateEdit)
                    throw new PermissionException("User_CreateEdit");

            User user = GetUser(email);

            return ChangePassword(oldPassword, newPassword, user);
        }
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            return ChangePassword(oldPassword, newPassword, IdentityProvider.User);
        }
        private bool ChangePassword(string oldPassword, string newPassword, User user)
        {
            if (user == null)
                return false;

            if (user.Password != Security.GetPasswordHash(oldPassword))
                return false;

            user.Password = Security.GetPasswordHash(newPassword);

            Context.SaveChanges();

            return true;
        }
        public bool ResetPassword(int userID)
        {
            if (!Permissions.User_CreateEdit)
                throw new PermissionException("User_CreateEdit");

            var user = GetUser(userID);
            if (user == null)
                throw new ArgumentException("User not exists");

            user.Password = Security.GetPasswordHash(DEF_PASSWORD);

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
            if (user == null)
                return false;

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

        public IQueryable<User> GetStudents()
        {
            string studentTypeName = UserTypes.Student.ToString();

            var result = Context.User.Where(u => u.IsActive == true && u.Type.Name == studentTypeName);
            if (!Permissions.User_List)
            {
                var groups = _managers.Get<GroupManager>().GetAll();
                result = result.Where(u => u.Groups.Any(g => groups.Contains(g)));
            }

            return result;
        }
        public User GetStudent(int studentID)
        {
            string studentTypeName = UserTypes.Student.ToString();

            return GetStudents().Where(u => u.ID == studentID).SingleOrDefault();
        }

        public IQueryable<User> GetLectors()
        {
            string studentTypeName = UserTypes.Student.ToString();

            return Context.User.Where(u => u.IsActive == true && u.Type.Name != studentTypeName);
        }

    }
}
