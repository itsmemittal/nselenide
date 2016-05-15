using OpenQA.Selenium;

namespace NSelenide.Impl
{
    public interface IWebDriverContainer
    {
        IWebDriver SetWebDriver(IWebDriver webDriver);
        IWebDriver GetWebDriver();
        void CloseWebDriver();
        bool HasWebDriverStarted();

        void ClearBrowserCache();
        string GetPageSource();
        string GetCurrentUrl();
        string GetCurrentFrameUrl();
    }
}
