using OpenQA.Selenium;

namespace Nselenide
{
    public class Selenide
    {
        private static readonly Navigator Navigator = new Navigator();

        protected void Open(string relativeOrAbsoluteUrl)
        {
            Navigator.Open(relativeOrAbsoluteUrl);
        }

        public SelenideElement Element(string cssSelector)
        {
            return new SelenideElement(null,By.CssSelector(cssSelector));
        }

        public SelenideElement Element(By by)
        {
            return new SelenideElement(null, by);
        }
    }

}
