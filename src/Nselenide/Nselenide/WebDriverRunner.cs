using OpenQA.Selenium.Chrome;

namespace Nselenide
{
    public class WebDriverRunner
    {
        private const string CHROME = "chrome";
        private const string INTERNET_EXPLORER = "ie";
        private const string FIREFOX = "firefox";
        private const string SAFARI = "safari";

        public static WebDriverContainer webDriverContainer = new WebDriverContainer();

        public static OpenQA.Selenium.IWebDriver GetWebDriver()
        {
           return webDriverContainer.GetWebDriver();
        }

        public static bool IsChrome()
        {
            return CHROME.Equals(Configuration.Browser);
        }

        public static bool IsIE()
        {
            return INTERNET_EXPLORER.Equals(Configuration.Browser);
        }
        public static bool IsFirefox()
        {
            return FIREFOX.Equals(Configuration.Browser);
        }
        public static bool IsSafari()
        {
            return SAFARI.Equals(Configuration.Browser);
        }

    }
}