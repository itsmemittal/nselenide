using NSelenide.Impl;
using OpenQA.Selenium;

namespace NSelenide
{
    public class DOM
    {
        private static readonly IWebDriver driver = WebDriverRunner.GetWebDriver();

        public void Open(string url)
        {
            string absoluteUrl;

            if (url.StartsWith("https") || url.StartsWith("http")|| url.StartsWith("file"))
            {
                absoluteUrl = url;
            }
            else
            {
                absoluteUrl = Settings.BaseUrl + url;
            }

           driver.Navigate().GoToUrl(absoluteUrl);
        }

        public PageElement Element(string selector)
        {
            return new PageElement(null, ByHelper.Create(selector));
        }

        public PageElement Element(ByHelper byhelper)
        {
            return new PageElement(null, byhelper);
        }

        public PageElementCollection Elements(string selector)
        {
            return new PageElementCollection(null, ByHelper.Create(selector));
        }

        public PageElementCollection Elements(ByHelper byhelper)
        {
            return new PageElementCollection(null, byhelper);
        }
    }
}
