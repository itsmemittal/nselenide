using OpenQA.Selenium;

namespace NSelenide.Impl.Conditions
{
    public class ClickableCondition : ICondition
    {
        public bool Apply(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public string ActualValue(IWebElement element)
        {
            return element.Displayed && element.Enabled
                ? "clickable"
                : "not clickable";
        }

        public override string ToString()
        {
            return "visible";
        }
    }
}
