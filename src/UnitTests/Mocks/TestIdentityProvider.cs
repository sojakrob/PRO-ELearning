using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Business.Permissions;
using ELearning.Business.Storages;
using ELearning.Data.Enums;
using ELearning.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Mocks
{
    public class TestIdentityProvider : ELearning.Business.Interfaces.IIdentityProvider
    {
        private const int ADMIN_ID = 1;
        private const int LECTOR_ID = 2;
        private const int STUDENT_ID = 3;


        public string AdminEmail { get { return _context.User.Single(u => u.ID == ADMIN_ID).Email; } }
        public string Lectormail { get { return _context.User.Single(u => u.ID == LECTOR_ID).Email; } }
        public string StudentEmail { get { return _context.User.Single(u => u.ID == STUDENT_ID).Email; } }


        private DataModelContainer _context;

        private UserTypes _currentUserType;
        private User _currentUser;



        /// <summary>
        /// Initializes a new instance of the TestIdentityProvider class.
        /// </summary>
        public TestIdentityProvider(IPersistentStorage storage)
        {
            _context = storage.GetDataContext();
            SetUser(UserTypes.Administrator);
        }


        public void SetUser(UserTypes type)
        {
            _currentUserType = type;

            int id = -1;
            switch (_currentUserType)
            {
                case UserTypes.Administrator:
                    id = ADMIN_ID;
                    break;
                case UserTypes.Lector:
                    id = LECTOR_ID;
                    break;
                case UserTypes.Student:
                    id = STUDENT_ID;
                    break;
                default:
                    throw new NotImplementedException();
            }
            _currentUser = _context.User.SingleOrDefault(u => u.ID == id);
            if (_currentUser == null)
                Assert.Fail("User not found");
        }


        #region IIdentityProvider Members

        public int UserID
        {
            get { return _currentUser.ID; }
        }

        public ELearning.Data.User User
        {
            get { return _currentUser; }
        }

        public UserPermissions GetPermissions()
        {
            
            return UserPermissions.Get(_currentUserType);
        }

        #endregion
    }
}
