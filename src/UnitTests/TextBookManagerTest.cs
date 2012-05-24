using ELearning.Business.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using ELearning.Business.Storages;
using ELearning.Business.Permissions;
using ELearning.Data;
using UnitTests.Mocks;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for TextBookManagerTest and is intended
    ///to contain all TextBookManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TextBookManagerTest
    {
        private string TITLE = "UnitTest TextBook";
        private string TEXT = "|H1 UnitTest TextBook";


        /// <summary>
        /// A test for AddTextBook
        ///</summary>
        [TestMethod]
        public void AddTextBookAsLectorTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Lector);

            var textBookManager = new TextBookManager(context.Storage, context.Container, context.IdentityProvider);

            int countBefore = textBookManager.GetAll().Count(t => t.Title == TITLE);
            if (countBefore != 0)
                Assert.Fail("Database is not clean");

            textBookManager.AddTextBook(TextBookManager.CreateNewTextBook(TITLE, TEXT));

            Assert.AreEqual(countBefore + 1, textBookManager.GetAll().Count(t => t.Title == TITLE));
        }
        [TestMethod]
        public void DeleteTextBookAsLectorTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Lector);

            var textBookManager = new TextBookManager(context.Storage, context.Container, context.IdentityProvider);

            int countBefore = textBookManager.GetAll().Count(t => t.Title == TITLE);
            if (countBefore == 0)
                Assert.Fail("TextBook is not present in DB");
            if (countBefore > 1)
                Assert.Fail("Database is not clean");

            var textBook = textBookManager.GetSingle(t => t.Title == TITLE);

            textBookManager.DeleteTextBook(textBook.ID);

            Assert.AreEqual(countBefore - 1, textBookManager.GetAll().Count(t => t.Title == TITLE));
        }
    }
}
