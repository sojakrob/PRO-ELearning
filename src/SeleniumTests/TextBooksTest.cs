using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumTests
{
    [TestClass]
    public class TextBooksTest
    {
        private const string TEXTBOOK_NAME = "Selenium TextBook test";
        private const string TEXTBOOK_NAME_EDITED = "Edited Selenium TextBook test";


        IWebDriver _driver = WebDriverContainer.Instance.WebDriver;


        [TestCleanup]
        public void TestCleanup()
        {
            BasicActions.LogOut();
        }


        [TestMethod]
        public void CreateNewTextBookAsLectorTest()
        {
            BasicActions.LogInAsLector();

            CreateNewTextBook();

            BasicActions.ClickLink(TEXTBOOK_NAME);
            BasicActions.CheckH1Text(TEXTBOOK_NAME);
        }
        [TestMethod]
        public void DeleteCreatedTextBookAsLectorTest()
        {
            BasicActions.LogInAsLector();

            DeleteTextBook();
        }

        [TestMethod]
        public void CreateAndDeleteTextBookAsStudentTest()
        {
            BasicActions.LogInAsStudent();

            CreateNewTextBook();
            DeleteTextBook();
        }

        [TestMethod]
        public void EditTextBookAsLectorTest()
        {
            BasicActions.LogInAsLector();

            CreateNewTextBook();

            BasicActions.ClickLink(ELearningResources.Strings.Edit);
            _driver.FindElement(By.Id("Title")).Clear();
            _driver.FindElement(By.Id("Title")).SendKeys(TEXTBOOK_NAME_EDITED);
            _driver.FindElement(By.Id("assignedGroupsGID2")).Click();
            _driver.FindElement(By.Id("VisibleToOthers")).Click();
            _driver.FindElement(By.Id("txtText")).Clear();
            _driver.FindElement(By.Id("txtText")).SendKeys("|H1 Edited Selenium TextBook test");
            _driver.FindElement(By.CssSelector("input.Button")).Click();

            BasicActions.ClickLink(ELearningResources.Strings.TextBooks);
            BasicActions.ClickLink(TEXTBOOK_NAME_EDITED);
            BasicActions.CheckH1Text(TEXTBOOK_NAME_EDITED);
            BasicActions.ClickLink(ELearningResources.Strings.TextBooks);

            DeleteTextBook(TEXTBOOK_NAME_EDITED);
        }

        private void CreateNewTextBook()
        {
            BasicActions.ClickLink(ELearningResources.Strings.CreateTextBook);
            _driver.FindElement(By.Id("Title")).Clear();
            _driver.FindElement(By.Id("Title")).SendKeys(TEXTBOOK_NAME);
            _driver.FindElement(By.Id("assignedGroupsGID2")).Click();
            _driver.FindElement(By.Id("VisibleToOthers")).Click();
            _driver.FindElement(By.Id("txtText")).Clear();
            _driver.FindElement(By.Id("txtText")).SendKeys("|H1 Selenium TextBook test");
            _driver.FindElement(By.CssSelector("input.Button")).Click();

            _driver.FindElement(By.LinkText(TEXTBOOK_NAME));
        }
        private void DeleteTextBook(string name = TEXTBOOK_NAME)
        {
            _driver.FindElement(By.XPath(string.Format("//a[text()=\"{0}\"]/parent::td/parent::tr/td[a=\"X\"]/a", name))).Click();
            try
            {
                _driver.FindElement(By.XPath(string.Format("//a[text()=\"{0}\"]/parent::td/parent::tr/td[a=\"X\"]/a", name)));
                Assert.Fail("TextBook was not deleted");
            }
            catch (NoSuchElementException ex) { }
        }
    }
}
