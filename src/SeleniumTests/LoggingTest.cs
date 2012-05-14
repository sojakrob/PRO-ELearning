using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumTests
{
    [TestClass]
    public class LoggingTest
    {
        [TestMethod]
        public void LogInAsAdminTest()
        {
            Assert.IsTrue(BasicActions.LogInAsAdmin());
        }
        [TestMethod]
        public void LogOutTest()
        {
            Assert.IsTrue(BasicActions.LogOut());
        }

        [TestMethod]
        public void LogAllUsersTest()
        {
            Assert.IsTrue(BasicActions.LogInAsAdmin());
            BasicActions.LogOut();
            Assert.IsTrue(BasicActions.LogInAsLector());
            BasicActions.LogOut();
            Assert.IsTrue(BasicActions.LogInAsStudent());
            BasicActions.LogOut();
        }

        [TestMethod]
        public void LogInWithWrongCredentials()
        {
            var driver = WebDriverContainer.Instance.WebDriver;

            driver.Navigate().GoToUrl(Config.BaseUrl);

            driver.FindElement(By.CssSelector("img[alt=\"EN\"]")).Click();

            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(Config.Username_Admin);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(Config.Password + "#");
            driver.FindElement(By.CssSelector("input.Button")).Click();

            Assert.IsNotNull(driver.FindElement(By.LinkText(ELearningResources.Strings.LogOn)));
        }
    }
}
