using System;
using NSelenide.Impl;
using OpenQA.Selenium;

namespace NSelenide
{
    public class WebDriverRunner
    {
        private static WebDriverContainer container = new WebDriverContainer();
        private const string CHROME = "chrome";
        private const string INTERNET_EXPLORER = "ie";
        private const string FIREFOX = "firefox";
        private const string SAFARI = "safari";

        
        public static bool IsChrome()
        {
            return CHROME.Equals(Settings.Browser,StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsFirefox()
        {
            return FIREFOX.Equals(Settings.Browser,StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsIE()
        {
            return INTERNET_EXPLORER.Equals(Settings.Browser,StringComparison.CurrentCultureIgnoreCase);
        }

        public static IWebDriver GetWebDriver()
        {
            return container.GetWebDriver();
        }

        public static void SetWebDriver(IWebDriver driver)
        {
        }

        public static void ClearBrowserCache()
        {
            container.ClearBrowserCache();
        }

        public static string CurrentFrameUrl()
        {
            return container.GetCurrentFrameUrl();
        }

        public static string Url()
        {
            return container.GetCurrentUrl();
        }

        public static string Source()
        {
            return container.GetPageSource();
        }

    }
}
