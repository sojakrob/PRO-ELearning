using ELearning.Business.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ELearning.Business.Storages;
using ELearning.Business.Interfaces;
using ELearning.Data.Enums;
using ELearning.Data;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for FormManagerTest and is intended
    ///to contain all FormManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FormManagerTest
    {
        private const string NAME = "UnitTest TrainingTest Form";
        private const string NAME_EDITED = "Edited UnitTest TrainingTest Form";
        private static readonly FormTypes TYPE = FormTypes.TrainingTest;
        private const string TEXT = "Form text";
        private const string TEXT_EDITED = "Edited Form text";
        private const int MAXFILLS = 5;
        private const int MAXFILLS_EDITED = 9;
        private const int TIMETOFILL = 10;
        private const int TIMETOFILL_EDITED = 5;
        private const bool SHUFFLE = true;
        private const bool SHUFFLE_EDITED = false;


        /// <summary>
        ///A test for AddForm
        ///</summary>
        [TestMethod()]
        public void CreateFormAsLectorTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Lector);

            var formManager = new FormManager(context.Storage, context.Container, context.IdentityProvider);

            int countBefore = CreateForm(formManager);

            Assert.AreEqual(countBefore + 1, formManager.GetNotArchivedForms().Count(f => f.Name == NAME));

            var form = formManager.GetNotArchivedForms().Single(f => f.Name == NAME);
            Assert.AreEqual(TYPE, form.TypeEnum);
            Assert.AreEqual(TEXT, form.Text);
            Assert.AreEqual(MAXFILLS, form.MaxFills);
            Assert.AreEqual(TIMETOFILL, form.TimeToFill);
            Assert.AreEqual(SHUFFLE, form.Shuffle);
            Assert.AreEqual(FormStates.Inactive, form.StateEnum);
            Assert.AreEqual(context.IdentityProvider.UserID, form.AuthorID);
        }

        [TestMethod]
        public void DeleteFormAsLectorTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Lector);

            var formManager = new FormManager(context.Storage, context.Container, context.IdentityProvider);

            int countBefore = formManager.GetNotArchivedForms().Count(f => f.Name == NAME);
            if (countBefore == 0)
                Assert.Fail("Form is not in DB");
            if (countBefore > 1)
                Assert.Fail("Database is not clean");

            DeleteForm(formManager);

            Assert.AreEqual(countBefore - 1, formManager.GetNotArchivedForms().Count(f => f.Name == NAME));
        }

        /// <summary>
        ///A test for EditForm
        ///</summary>
        [TestMethod()]
        public void EditFormTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Lector);

            var formManager = new FormManager(context.Storage, context.Container, context.IdentityProvider);

            int countBefore = CreateForm(formManager);

            var form = formManager.GetNotArchivedForms().Single(f => f.Name == NAME);
            form.Name = NAME_EDITED;
            form.Text = TEXT_EDITED;
            form.MaxFills = MAXFILLS_EDITED;
            form.TimeToFill = TIMETOFILL_EDITED;
            form.Shuffle = SHUFFLE_EDITED;

            formManager.EditForm(form);

            form = formManager.GetNotArchivedForms().Single(f => f.Name == NAME_EDITED);
            Assert.AreEqual(TEXT_EDITED, form.Text);
            Assert.AreEqual(TYPE, form.TypeEnum);
            Assert.AreEqual(MAXFILLS_EDITED, form.MaxFills);
            Assert.AreEqual(TIMETOFILL_EDITED, form.TimeToFill);
            Assert.AreEqual(SHUFFLE_EDITED, form.Shuffle);
            Assert.AreEqual(context.IdentityProvider.UserID, form.AuthorID);

            DeleteForm(formManager, NAME_EDITED);
        }

        /// <summary>
        ///A test for ChangeFormStateAndDeletePreviews
        ///</summary>
        [TestMethod()]
        public void ChangeFormStateAndDeletePreviewsTest()
        {
            var context = new TestContextContainer();
            context.IdentityProvider.SetUser(ELearning.Data.Enums.UserTypes.Lector);

            var formManager = new FormManager(context.Storage, context.Container, context.IdentityProvider);

            CreateForm(formManager);

            var form = formManager.GetNotArchivedForms().Single(f => f.Name == NAME);
            Assert.AreEqual(FormStates.Inactive, form.StateEnum);

            formManager.ChangeFormStateAndDeletePreviews(form.ID, FormStates.Active);

            form = formManager.GetNotArchivedForms().Single(f => f.Name == NAME);
            Assert.AreEqual(FormStates.Active, form.StateEnum);

            formManager.ChangeFormStateAndDeletePreviews(form.ID, FormStates.Inactive);

            form = formManager.GetNotArchivedForms().Single(f => f.Name == NAME);
            Assert.AreEqual(FormStates.Inactive, form.StateEnum);

            DeleteForm(formManager);
        }


        private static int CreateForm(FormManager formManager)
        {
            int countBefore = formManager.GetNotArchivedForms().Count(f => f.Name == NAME);
            if (countBefore > 0)
                Assert.Fail("Database is not clean");

            var newForm = Form.CreateForm(0, NAME, DateTime.Now, (int)TYPE, 0);
            newForm.Text = TEXT;
            newForm.MaxFills = MAXFILLS;
            newForm.TimeToFill = TIMETOFILL;
            newForm.Shuffle = SHUFFLE;

            formManager.AddForm(newForm);
            return countBefore;
        }
        private static void DeleteForm(FormManager formManager, string formName = NAME)
        {
            var form = formManager.GetNotArchivedForms().Single(f => f.Name == formName);

            formManager.DeleteForm(form.ID);
        }
    }
}
