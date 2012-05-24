using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class UsersTest
    {
        private const string STUDENT_EMAIL = "SeleniumStudent@test.test";
        private const string STUDENT_PASSWORD = "Pass123";
        private const string STUDENT_NAME = "SeleniumStudent";
        private const string LECTOR_EMAIL = "SeleniumLector@test.test";
        private const string LECTOR_PASSWORD = "Pass123";
        private const string LECTOR_NAME = "SeleniumLector";

        IWebDriver _driver = WebDriverContainer.Instance.WebDriver;


        [TestCleanup]
        public void TestCleanup()
        {
            BasicActions.LogOut();
        }


        [TestMethod]
        public void AddStudentAsAdminTest()
        {
            BasicActions.LogInAsAdmin();

            AddStudent();

            BasicActions.LogOut();
            BasicActions.LogIn(STUDENT_EMAIL, STUDENT_PASSWORD);
        }
        [TestMethod]
        public void DeleteCreatedStudentAsAdminTest()
        {
            BasicActions.LogInAsAdmin();

            DeleteStudent();
        }

        [TestMethod]
        public void AssignUserToGroupAsAdminTest()
        {
            BasicActions.LogInAsAdmin();

            AddStudent();

            BasicActions.ClickLink(ELearningResources.Strings.Groups);
            BasicActions.ClickLink(ELearningResources.Strings.Edit);

            _driver.FindElement(By.XPath(string.Format("//td[a=\"{0}\"]/parent::tr/td/input", STUDENT_NAME))).Click();
            _driver.FindElement(By.CssSelector("input.Button")).Click();

            DeleteStudent();
        }

        [TestMethod]
        public void AddLectorAsAdminTest()
        {
            BasicActions.LogInAsAdmin();

            AddLector();

            BasicActions.LogOut();
            BasicActions.LogIn(LECTOR_EMAIL, LECTOR_PASSWORD);
        }
        [TestMethod]
        public void DeleteCreatedLectorAsAdminTest()
        {
            BasicActions.LogInAsAdmin();

            DeleteLector();
        }


        private void AddStudent()
        {
            BasicActions.ClickLink(ELearningResources.Strings.NewUser);
            _driver.FindElement(By.Id("Email")).Clear();
            _driver.FindElement(By.Id("Email")).SendKeys(STUDENT_EMAIL);
            _driver.FindElement(By.Id("Password")).Clear();
            _driver.FindElement(By.Id("Password")).SendKeys(STUDENT_PASSWORD);
            new SelectElement(_driver.FindElement(By.Id("Type_ID"))).SelectByText(ELearningResources.Strings.Student);
            _driver.FindElement(By.CssSelector("input.Button")).Click();

            _driver.FindElement(By.XPath(string.Format("//td[\"{0}\"]", STUDENT_EMAIL)));
        }
        private void AddLector()
        {
            BasicActions.ClickLink(ELearningResources.Strings.NewUser);
            _driver.FindElement(By.Id("Email")).Clear();
            _driver.FindElement(By.Id("Email")).SendKeys(LECTOR_EMAIL);
            _driver.FindElement(By.Id("Password")).Clear();
            _driver.FindElement(By.Id("Password")).SendKeys(LECTOR_PASSWORD);
            new SelectElement(_driver.FindElement(By.Id("Type_ID"))).SelectByText(ELearningResources.Strings.Lector);
            _driver.FindElement(By.CssSelector("input.Button")).Click();

            _driver.FindElement(By.XPath(string.Format("//td[\"{0}\"]", LECTOR_EMAIL)));
        }
        private void DeleteStudent()
        {
            BasicActions.ClickLink(ELearningResources.Strings.Users);
            _driver.FindElement(By.XPath(string.Format("//tr[td=\"{0}\"]/td[a=\"X\"]/a", STUDENT_EMAIL))).Click();

            try
            {
                _driver.FindElement(By.XPath(string.Format("//tr[td=\"{0}\"]", STUDENT_EMAIL)));
                Assert.Fail("Student was not deleted");
            }
            catch (NoSuchElementException) { }
        }
        private void DeleteLector()
        {
            BasicActions.ClickLink(ELearningResources.Strings.Users);
            _driver.FindElement(By.XPath(string.Format("//tr[td=\"{0}\"]/td[a=\"X\"]/a", LECTOR_EMAIL))).Click();

            try
            {
                _driver.FindElement(By.XPath(string.Format("//tr[td=\"{0}\"]", LECTOR_EMAIL)));
                Assert.Fail("Student was not deleted");
            }
            catch (NoSuchElementException) { }
        }

    }
}
