using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTests
{
    internal sealed class WebDriverContainer : IDisposable
    {
        private static readonly object _padlock = new object();

        /// <summary>
        /// Gets singleton instance
        /// </summary>
        public static WebDriverContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                            _instance = new WebDriverContainer();
                    }
                }

                return _instance;
            }
        }
        private static WebDriverContainer _instance;

        public IWebDriver WebDriver { get; private set; }


        /// <summary>
        /// Initializes a new instance of the WebDriverContainer class.
        /// </summary>
        public WebDriverContainer()
        {
            WebDriver = new FirefoxDriver();
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                WebDriver.Close();
            }
            catch
            {
            }
        }

        #endregion
    }
}
