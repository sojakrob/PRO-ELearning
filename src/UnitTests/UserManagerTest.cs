using ELearning.Business.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ELearning.Business.Storages;
using ELearning.Business.Interfaces;
using ELearning.Business.Permissions;
using ELearning.Data;
using System.Linq;
using ELearning.Data.Enums;
using ELearning.Business;

namespace UnitTests
{
    
    /// <summary>
    ///This is a test class for UserManagerTest and is intended
    ///to contain all UserManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserManagerTest
    {
        private const string STUDENT_EMAIL = "UnitTestStudent@test.test";
        private const string LECTOR_EMAIL = "UnitTestLector@test.test";
        private const string STUDENT_PASSWORD = "Pass123";
        private const string STUDENT_PASSWORD_EDITED = "pass321";
        private const string LECTOR_PASSWORD = "Pass123";


        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateStudentTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Administrator);

            var userManager = new UserManager(context.Storage, context.Container, context.IdentityProvider);

            CreateUserAndValidate(userManager, STUDENT_EMAIL, STUDENT_PASSWORD, UserTypes.Student);
        }
        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        [TestMethod()]
        public void DeleteStudentTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Administrator);

            var userManager = new UserManager(context.Storage, context.Container, context.IdentityProvider);

            DeleteUserAndValidate(userManager, STUDENT_EMAIL);
        }

        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateLectorTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Administrator);

            var userManager = new UserManager(context.Storage, context.Container, context.IdentityProvider);

            CreateUserAndValidate(userManager, LECTOR_EMAIL, LECTOR_PASSWORD, UserTypes.Lector);
        }
        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        [TestMethod()]
        public void DeleteLectorTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Administrator);

            var userManager = new UserManager(context.Storage, context.Container, context.IdentityProvider);

            DeleteUserAndValidate(userManager, LECTOR_EMAIL);
        }


        /// <summary>
        ///A test for GetUserPermissions
        ///</summary>
        [TestMethod()]
        public void GetUserPermissionsTest()
        {
            
        }

        /// <summary>
        ///A test for GetStudents
        ///</summary>
        [TestMethod()]
        public void GetStudentsTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Administrator);

            var userManager = new UserManager(context.Storage, context.Container, context.IdentityProvider);

            var students = userManager.GetStudents();
            foreach (var student in students)
                Assert.AreEqual(UserTypes.Student, student.TypeEnum);
        }

        /// <summary>
        ///A test for GetLectors
        ///</summary>
        [TestMethod()]
        public void GetLectorsTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Administrator);

            var userManager = new UserManager(context.Storage, context.Container, context.IdentityProvider);

            var lectors = userManager.GetLectors();
            foreach (var lector in lectors)
                if (lector.TypeEnum != UserTypes.Lector && lector.TypeEnum != UserTypes.Administrator)
                    Assert.Fail("User is not lector");
        }


        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Administrator);

            var userManager = new UserManager(context.Storage, context.Container, context.IdentityProvider);

            CreateUserAndValidate(userManager, STUDENT_EMAIL, STUDENT_PASSWORD, UserTypes.Student);

            userManager.ChangePassword(STUDENT_EMAIL, STUDENT_PASSWORD, STUDENT_PASSWORD_EDITED);

            var user = userManager.GetUser(STUDENT_EMAIL);
            Assert.AreEqual(Security.GetPasswordHash(STUDENT_PASSWORD_EDITED), user.Password);

            DeleteUserAndValidate(userManager, STUDENT_EMAIL);
        }


        private static void CreateUserAndValidate(UserManager userManager, string email, string password, UserTypes type)
        {
            var user = userManager.GetUser(email);
            if (user != null)
                Assert.Fail("Database is not clean");

            userManager.CreateUser(email, password, type);

            user = userManager.GetUser(email);
            Assert.IsNotNull(user);
            Assert.AreEqual(Security.GetPasswordHash(password), user.Password);
            Assert.IsTrue(user.IsActive);
        }
        private static void DeleteUserAndValidate(UserManager userManager, string email)
        {
            var user = userManager.GetUser(email);
            Assert.IsNotNull(user);

            userManager.DeleteUser(email);

            user = userManager.GetUser(email);
            Assert.IsNull(user);
        }
    }
}
