using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Nselenide
{
    public class WebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            IWebDriver driver =  WebDriverRunner.IsFirefox() ? CreateFirefoxDriver() : CreateInternetExploreDriver();
            driver = Maximize(driver);
            return driver;
        }

        private IWebDriver Maximize(IWebDriver driver)
        {
            if (Configuration.Maximize)
            {
                driver.Manage().Window.Maximize();
            }

            return driver;
        }

        private IWebDriver CreateFirefoxDriver()
        {
            DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
            IWebDriver driver =  new FirefoxDriver();
            return driver;
        }

        private IWebDriver CreateInternetExploreDriver()
        {
            return  new InternetExplorerDriver();
        }
    }
}