using NSelenide.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace NSelenide.WebDriver
{
    public class WebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            IWebDriver driver = WebDriverRunner.IsFirefox() ? CreateFirefoxDriver() : CreateFirefoxDriver();
            driver = Maximize(driver);
            return driver;
        }

        private IWebDriver Maximize(IWebDriver driver)
        {
            if (Settings.StartMaximize)
            {
                driver.Manage().Window.Maximize();
            }

            return driver;
        }

        private IWebDriver CreateFirefoxDriver()
        {
            DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
    }
}
