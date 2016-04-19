using OpenQA.Selenium;

namespace Nselenide.Exceptions
{
    public class UnReachableBrowserException : WebDriverException
    {
        public UnReachableBrowserException(string message): base(message)
        {
            
        }
    }
}