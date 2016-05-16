using System;
using NSelenide.Exceptions;
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

            if (url.StartsWith("https") || url.StartsWith("http") || url.StartsWith("file"))
            {
                absoluteUrl = url;
            }
            else
            {
                absoluteUrl = Settings.BaseUrl + url;
            }

            driver.Navigate().GoToUrl(absoluteUrl);
            MockDialog();
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

        public AlertDialog Alert(int timeout = 0)
        {
            return new AlertDialog(timeout);
        }

        private void MockDialog()
        {
            if (Settings.MockDialogs)
            {
                string jsCode =
                    "  window._nselenide_modalDialogReturnValue = true;\n" +
                    "  window.alert = function(message) {};\n" +
                    "  window.confirm = function(message) {\n" +
                    "    return window._selenide_modalDialogReturnValue;\n" +
                    "  };";
                ExecuteJavaScript(jsCode);
            }
        }

        private void ExecuteJavaScript(string jsCode)
        {
            ((IJavaScriptExecutor) driver).ExecuteScript(jsCode);
        }
    }
}
