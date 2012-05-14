using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumTests
{
    [TestClass]
    public class FormsTest
    {
        private const string TRAINING_FORM_NAME = "Selenium test form";
        IWebDriver _driver = WebDriverContainer.Instance.WebDriver;

        [TestCleanup]
        public void TestCleanup()
        {
            BasicActions.LogOut();
        }

        [TestMethod]
        public void CreateFormAsAdminTest()
        {
            BasicActions.LogInAsAdmin();

            CreateTrainingTestForm();
        }
        [TestMethod]
        public void DeleteTrainingTestFormAsAdminTest()
        {
            BasicActions.LogInAsAdmin();

            DeleteTrainingTestForm();
        }

        [TestMethod]
        public void CreateFormAsLectorTest()
        {
            BasicActions.LogInAsLector();

            CreateTrainingTestForm();
        }

        [TestMethod]
        public void DeleteTrainingTestFormAsLectorTest()
        {
            BasicActions.LogInAsLector();

            DeleteTrainingTestForm(); 
        }

        [TestMethod]
        public void DeleteTrainingTestFormCreatedByLectorAsAdminTest()
        {
            BasicActions.LogInAsLector();

            CreateTrainingTestForm();

            BasicActions.LogOut();
            BasicActions.LogInAsAdmin();

            DeleteTrainingTestForm();
        }


        private void CreateTrainingTestForm()
        {
            BasicActions.ClickLink(ELearningResources.Strings.CreateForm);

            _driver.FindElement(By.Id("Name")).Clear();
            _driver.FindElement(By.Id("Name")).SendKeys(TRAINING_FORM_NAME);
            new SelectElement(_driver.FindElement(By.Id("Type_ID"))).SelectByText(ELearningResources.Strings.TrainingTest);
            _driver.FindElement(By.Id("Text")).Clear();
            _driver.FindElement(By.Id("Text")).SendKeys("This is Selenium test form.");
            _driver.FindElement(By.Id("TimeToFill")).Clear();
            _driver.FindElement(By.Id("TimeToFill")).SendKeys("12");
            _driver.FindElement(By.Id("MaxFills")).Clear();
            _driver.FindElement(By.Id("MaxFills")).SendKeys("30");
            _driver.FindElement(By.Id("Shuffle")).Click();
            _driver.FindElement(By.Id("assignedGroupsGID2")).Click();
            _driver.FindElement(By.CssSelector("input.Button")).Click();

            BasicActions.CheckH2Text(TRAINING_FORM_NAME);
        }
        private void DeleteTrainingTestForm()
        {
            BasicActions.ClickLink(ELearningResources.Strings.Forms);

            _driver.FindElement(By.XPath(string.Format("//a[@title=\"{0}\"]/parent::td/parent::tr/td[a=\"X\"]/a", TRAINING_FORM_NAME))).Click();
        }
    }
}
