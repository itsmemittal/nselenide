using System.Collections.Generic;
using System.Runtime.InteropServices;
using NSelenide.WebDriver;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.Extensions;

namespace NSelenide.Impl
{
    public class WebDriverContainer : IWebDriverContainer
    {
        private readonly  WebDriverFactory factory = new WebDriverFactory();
        private readonly Dictionary<int, IWebDriver> driverthreads = new Dictionary<int, IWebDriver>();

        private bool IsBrowserStillOpen(IWebDriver driver)
        {
            try
            {
                var title = driver.Title;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IWebDriver SetWebDriver(IWebDriver webDriver)
        {
            driverthreads.Add(Thread.CurrentThread.ManagedThreadId, webDriver);
            return webDriver;
        }

        public IWebDriver GetWebDriver()
        {
            IWebDriver driver;
            driverthreads.TryGetValue(Thread.CurrentThread.ManagedThreadId, out driver);
            if (driver == null) return SetWebDriver(factory.CreateDriver());
            if (IsBrowserStillOpen(driver))
            {
                return driver;
            }
            
            CloseWebDriver();
            return SetWebDriver(factory.CreateDriver());
        }

        public void CloseWebDriver()
        {
            driverthreads.Remove(Thread.CurrentThread.ManagedThreadId);

        }

        public bool HasWebDriverStarted()
        {
            return driverthreads.ContainsKey(Thread.CurrentThread.ManagedThreadId);
        }

        public void ClearBrowserCache()
        {
            IWebDriver driver;
            driverthreads.TryGetValue(Thread.CurrentThread.ManagedThreadId, out driver);
            if (driver != null)
            {
                driver.Manage().Cookies.DeleteAllCookies();
            }
        }

        public string GetPageSource()
        {
            return GetWebDriver().PageSource;
        }

        public string GetCurrentUrl()
        {
            return GetWebDriver().Url;
        }

        public string GetCurrentFrameUrl()
        {
            return ((IJavaScriptExecutor) GetWebDriver()).ExecuteScript("return window.location.href").ToString();
        }

    }
}
