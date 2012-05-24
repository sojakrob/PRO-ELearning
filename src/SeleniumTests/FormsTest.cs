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
        private const string TRAINING_FORM_NAME_EDITED = "Edited Selenium test form";

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
        public void EditTrainingTestLectorTest()
        {
            BasicActions.LogInAsLector();

            CreateTrainingTestForm();
            EditTrainingTestForm();
            DeleteTrainingTestForm(TRAINING_FORM_NAME_EDITED);
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

        [TestMethod]
        public void FillTrainingTestFormAsStudentTest()
        {
            BasicActions.LogInAsLector();

            CreateTrainingTestForm();
            ActivateTrainingTestForm();

            BasicActions.LogOut();
            BasicActions.LogInAsStudent();

            FillTrainingTestForm();

            BasicActions.LogOut();
            BasicActions.LogInAsLector();

            DeleteTrainingTestForm();
        }

        [TestMethod]
        public void ViewAndEvaluateTrainingTestResultsAsLectorTest()
        {
            BasicActions.LogInAsLector();

            CreateTrainingTestForm();
            ActivateTrainingTestForm();

            BasicActions.LogOut();
            BasicActions.LogInAsStudent();

            FillTrainingTestForm();

            BasicActions.LogOut();
            BasicActions.LogInAsLector();

            _driver.FindElement(By.LinkText("1 / 1")).Click();
            _driver.FindElement(By.LinkText(Config.DisplayName_Student)).Click();
            _driver.FindElement(By.LinkText(TRAINING_FORM_NAME)).Click();

            SwitchToTrainingTestWindow();

            new SelectElement(_driver.FindElement(By.Id("markValues"))).SelectByText("B");
            _driver.FindElement(By.Id("Evaluation_Note")).Clear();
            _driver.FindElement(By.Id("Evaluation_Note")).SendKeys("Good");
            _driver.FindElement(By.CssSelector("fieldset > input.Button")).Click();
            _driver.FindElement(By.CssSelector("#FormFillFooter > input.Button")).Click();

            SwitchBackFromTrainingTestWindow(string.Format(ELearningResources.Strings.StudentDetail_format, Config.DisplayName_Student));

            DeleteTrainingTestForm();

            BasicActions.LogOut();
            BasicActions.LogInAsStudent();

            BasicActions.ClickLink(ELearningResources.Strings.FilledForms);
            _driver.FindElement(By.XPath(string.Format("//a[text()=\"{0}\"]/parent::td/parent::tr/td[span=\"B\"]", TRAINING_FORM_NAME)));
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
        private void ActivateTrainingTestForm()
        {
            BasicActions.ClickLink(ELearningResources.Strings.Forms);

            _driver.FindElement(
                By.XPath(
                    string.Format(
                        "//a[@title=\"{0}\"]/parent::td/parent::tr/td[a=\"{1}\"]/a", 
                        TRAINING_FORM_NAME, 
                        ELearningResources.Strings.Activate
                        )
                    )
                ).Click();

            _driver.FindElement(
                By.XPath(
                    string.Format(
                        "//a[@title=\"{0}\"]/parent::td/parent::tr/td[a=\"{1}\"]/a",
                        TRAINING_FORM_NAME,
                        ELearningResources.Strings.Deactivate
                        )
                    )
                );
        }
        private void EditTrainingTestForm()
        {
            BasicActions.ClickLink(ELearningResources.Strings.Forms);

            _driver.FindElement(By.LinkText(TRAINING_FORM_NAME)).Click();
            _driver.FindElement(By.LinkText(ELearningResources.Strings.Edit)).Click();

            _driver.FindElement(By.Id("Name")).Clear();
            _driver.FindElement(By.Id("Name")).SendKeys(TRAINING_FORM_NAME_EDITED);
            _driver.FindElement(By.Id("Text")).Clear();
            _driver.FindElement(By.Id("Text")).SendKeys("This is edited Selenium test form.");
            _driver.FindElement(By.Id("TimeToFill")).Clear();
            _driver.FindElement(By.Id("TimeToFill")).SendKeys("15");
            _driver.FindElement(By.Id("MaxFills")).Clear();
            _driver.FindElement(By.Id("MaxFills")).SendKeys("46");
            _driver.FindElement(By.Id("Shuffle")).Click();
            _driver.FindElement(By.Id("assignedGroupsGID2")).Click();
            _driver.FindElement(By.CssSelector("input.Button")).Click();

            BasicActions.ClickLink(TRAINING_FORM_NAME_EDITED);
            BasicActions.CheckH2Text(TRAINING_FORM_NAME_EDITED);
        }
        private void DeleteTrainingTestForm(string formName = TRAINING_FORM_NAME)
        {
            BasicActions.ClickLink(ELearningResources.Strings.Forms);

            _driver.FindElement(By.XPath(string.Format("//a[@title=\"{0}\"]/parent::td/parent::tr/td[a=\"X\"]/a", formName))).Click();
        }
        private void FillTrainingTestForm()
        {
            BasicActions.ClickLink(TRAINING_FORM_NAME);
            BasicActions.ClickLink(ELearningResources.Strings.Start);

            SwitchToTrainingTestWindow();

            _driver.FindElement(By.CssSelector("input.Button")).Click();
            _driver.FindElement(By.CssSelector("input.Button")).Click();

            SwitchBackFromTrainingTestWindow(ELearningResources.Strings.Home);
        }

        private void SwitchToTrainingTestWindow()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            bool fillingFormH2Found = wait.Until<bool>(
                (d) =>
                {
                    try
                    {
                        _driver.SwitchTo().Window(_driver.WindowHandles[1]);
                    }
                    catch { }
                    return d.FindElement(By.TagName("h2")).Text.ToUpper() == TRAINING_FORM_NAME.ToUpper();
                }
                );
        }
        private void SwitchBackFromTrainingTestWindow(string h1Text)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            bool isHomeVisible = wait.Until<bool>(
                (d) =>
                {
                    try
                    {
                        _driver.SwitchTo().Window(_driver.WindowHandles[0]);
                    }
                    catch { }
                    return d.FindElement(By.TagName("h1")).Text.ToUpper() == h1Text.ToUpper();
                }
                );
        }
    }
}
