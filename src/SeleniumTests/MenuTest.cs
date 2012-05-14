using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumTests
{
    [TestClass]
    public class MenuTest
    {
        IWebDriver _driver = WebDriverContainer.Instance.WebDriver;

        [TestCleanup]
        public void TestCleanup()
        {
            BasicActions.LogOut();
        }

        [TestMethod]
        public void AdminTest()
        {
            BasicActions.LogInAsAdmin();

            CheckIsActionPresentAndWorking(ELearningResources.Strings.CreateForm, ELearningResources.Strings.NewForm);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Forms, ELearningResources.Strings.AvailableForms);
            CheckIsActionNotPresent(ELearningResources.Strings.AvailableForms);
            CheckIsActionNotPresent(ELearningResources.Strings.FilledForms);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.CreateTextBook, ELearningResources.Strings.NewTextBook);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.TextBooks, ELearningResources.Strings.TextBooks);
            CheckIsActionNotPresent(ELearningResources.Strings.Students);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Groups, ELearningResources.Strings.Groups);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.NewUser, ELearningResources.Strings.NewUser);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Users, ELearningResources.Strings.Users);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.NewGroup, ELearningResources.Strings.NewGroup);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.UserGroups, ELearningResources.Strings.Groups);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Settings, ELearningResources.Strings.Settings);
        }
        [TestMethod]
        public void LectorTest()
        {
            BasicActions.LogInAsLector();

            CheckIsActionPresentAndWorking(ELearningResources.Strings.CreateForm, ELearningResources.Strings.NewForm);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Forms, ELearningResources.Strings.AvailableForms);
            CheckIsActionNotPresent(ELearningResources.Strings.AvailableForms);
            CheckIsActionNotPresent(ELearningResources.Strings.FilledForms);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.CreateTextBook, ELearningResources.Strings.NewTextBook);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.TextBooks, ELearningResources.Strings.TextBooks);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Students, ELearningResources.Strings.Students);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Groups, ELearningResources.Strings.Groups);
            CheckIsActionNotPresent(ELearningResources.Strings.NewUser);
            CheckIsActionNotPresent(ELearningResources.Strings.Users);
            CheckIsActionNotPresent(ELearningResources.Strings.NewGroup);
            CheckIsActionNotPresent(ELearningResources.Strings.UserGroups);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Settings, ELearningResources.Strings.Settings);
        }
        [TestMethod]
        public void StudentTest()
        {
            BasicActions.LogInAsStudent();

            CheckIsActionNotPresent(ELearningResources.Strings.CreateForm);
            CheckIsActionNotPresent(ELearningResources.Strings.Forms);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.AvailableForms, ELearningResources.Strings.AvailableForms);

            BasicActions.ClickLink(ELearningResources.Strings.FilledForms);
            BasicActions.CheckIsCaptionPresent(ELearningResources.Strings.FilledForms);

            CheckIsActionPresentAndWorking(ELearningResources.Strings.CreateTextBook, ELearningResources.Strings.NewTextBook);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.TextBooks, ELearningResources.Strings.TextBooks);
            CheckIsActionNotPresent(ELearningResources.Strings.Students);
            CheckIsActionNotPresent(ELearningResources.Strings.Groups);
            CheckIsActionNotPresent(ELearningResources.Strings.NewUser);
            CheckIsActionNotPresent(ELearningResources.Strings.Users);
            CheckIsActionNotPresent(ELearningResources.Strings.NewGroup);
            CheckIsActionNotPresent(ELearningResources.Strings.UserGroups);
            CheckIsActionPresentAndWorking(ELearningResources.Strings.Settings, ELearningResources.Strings.Settings);
        }


        private void CheckIsActionPresentAndWorking(string linkText, string finalH1Text)
        {
            BasicActions.ClickLink(linkText);

            BasicActions.CheckH1Text(finalH1Text);
        }
        
        private void CheckIsActionNotPresent(string linkText)
        {
            try
            {
                _driver.FindElement(By.LinkText(linkText));
                Assert.Fail(string.Format("Error: Action {0} was found", linkText));
            }
            catch
            {
                
            }
        }
    }
}
