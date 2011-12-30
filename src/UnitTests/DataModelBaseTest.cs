using ELearning.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using ELearning.Business.Storages;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for DataModelBaseTest and is intended
    ///to contain all DataModelBaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataModelBaseTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void CreateFromArrayTest()
        {
            List<Form> forms = new List<Form>();
            forms.Add(Form.CreateForm(0, "Form 0", DateTime.Now, 0, 0));
            forms.Add(Form.CreateForm(1, "Form 1", DateTime.Now, 0, 0));
            forms.Add(Form.CreateForm(2, "Form 2", DateTime.Now, 0, 0));

            IList<FormModel> formModels = DataModelBase<Form>.CreateFromArray<FormModel>(forms);

            Assert.AreEqual(forms.Count, formModels.Count);

            for (int i = 0; i < forms.Count; i++)
            {
                Assert.AreEqual(forms[i].ID, formModels[i].ID);
                Assert.AreEqual(forms[i].Name, formModels[i].Name);
                Assert.AreEqual(forms[i].Text, formModels[i].Text);
            }
        }
    }
}
