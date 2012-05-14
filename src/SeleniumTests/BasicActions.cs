using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTests
{
    internal class BasicActions
    {
        public static bool LogInAsAdmin()
        {
            return LogIn(Config.Username_Admin);
        }
        public static bool LogInAsLector()
        {
            return LogIn(Config.Username_Lector);
        }
        public static bool LogInAsStudent()
        {
            return LogIn(Config.Username_Student);
        }
        private static bool LogIn(string username)
        {
            var driver = WebDriverContainer.Instance.WebDriver;

            driver.Navigate().GoToUrl(Config.BaseUrl);

            driver.FindElement(By.CssSelector("img[alt=\"EN\"]")).Click();

            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(username);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(Config.Password);
            driver.FindElement(By.CssSelector("input.Button")).Click();

            return driver.FindElement(By.TagName("h1")).Text.ToUpper() == ELearningResources.Strings.Home.ToUpper();
        }

        public static bool LogOut()
        {
            var driver = WebDriverContainer.Instance.WebDriver;

            driver.FindElement(By.LinkText(ELearningResources.Strings.LogOff)).Click();

            return driver.FindElement(By.LinkText(ELearningResources.Strings.LogOn)) != null;
        }

        public static void CheckIsCaptionPresent(string caption)
        {
            var captionElement = WebDriverContainer.Instance.WebDriver.FindElements(By.TagName("caption")).Any(c => c.Text.ToUpper() == caption.ToUpper());
            Assert.IsNotNull(captionElement);
        }

        public static void ClickLink(string linkText)
        {
            try
            {
                WebDriverContainer.Instance.WebDriver.FindElement(By.LinkText(linkText)).Click();
            }
            catch
            {
                Assert.Fail(String.Format("Link {0} not found", linkText));
            }
        }

        public static void CheckH1Text(string text)
        {
            CheckTagText("h1", text);
        }
        public static void CheckH2Text(string text)
        {
            CheckTagText("h2", text);
        }
        public static void CheckTagText(string tag, string text)
        {
            string elementText = WebDriverContainer.Instance.WebDriver.FindElement(By.TagName(tag)).Text.ToUpper();
            Assert.AreEqual(text.ToUpper(), elementText);
        }
    }
}
