using System.Collections.Generic;
using Nselenide.Exceptions;
using OpenQA.Selenium;

namespace Nselenide
{
    public class WebDriverContainer
    {
        protected static WebDriverFactory factory = new WebDriverFactory();
        protected Dictionary<int,IWebDriver> ThreadWebDrivers = new Dictionary<int, IWebDriver>();

        protected bool IsBrowserStillOpen(IWebDriver driver)
        {
            try
            {
                var title = driver.Title;
                return true;
            }
            catch (UnReachableBrowserException exception)
            {
                //log.log(FINE, "Browser is unreachable", e);
                return false;
            }
            catch (NoSuchWindowException e)
            {
                //log.log(FINE, "Browser window is now found", e);
                return false;
            }
            catch (WebDriverException e)
            {
                //log.log(FINE, "Browser session is not found", e);
                return false;
            }
        }

        public IWebDriver GetWebDriver()
        {
            //existing Web driver
            IWebDriver webDriver;
            ThreadWebDrivers.TryGetValue(System.Threading.Thread.CurrentThread.ManagedThreadId, out webDriver);
            if (webDriver != null)
            {
                if (IsBrowserStillOpen(webDriver))
                {
                    return webDriver;
                }

                //log.info("Webdriver has been closed meanwhile. Let's re-create it.");
                CloseWebDriver();
            }

            return SetWebDriver(factory.CreateDriver());
        }

        private void CloseWebDriver()
        {
            ThreadWebDrivers.Clear();
        }

        public IWebDriver SetWebDriver(IWebDriver driver)
        {
            ThreadWebDrivers.Add(System.Threading.Thread.CurrentThread.ManagedThreadId, driver);
            return driver;
        }
    }
}
