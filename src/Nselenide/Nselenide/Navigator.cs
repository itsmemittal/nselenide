using OpenQA.Selenium;

namespace Nselenide
{
    public class Navigator
    {
        public void Open(string absoluteRelativeUrl)
        {
            if (absoluteRelativeUrl.StartsWith("https:") || absoluteRelativeUrl.StartsWith("http:"))
            {
                NavigateToAbsoluteUrl(absoluteRelativeUrl);
            }
            if (string.IsNullOrEmpty(absoluteRelativeUrl))
            {
                
            }
        }

        private void NavigateToAbsoluteUrl(string absoluteRelativeUrl)
        {
            IWebDriver driver = WebDriverRunner.GetWebDriver();
            driver.Navigate().GoToUrl(absoluteRelativeUrl);
        }
    }
}
