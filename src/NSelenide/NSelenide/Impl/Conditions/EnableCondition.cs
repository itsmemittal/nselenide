namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    public class EnableCondition : ICondition
    {
        public bool Apply(IWebElement element)
        {
            return element.Enabled;
        }

        public string ActualValue(IWebElement element)
        {
            return element.Enabled ? "enabled" : "not enabled";
        }

        public override string ToString()
        {
            return "enabled";
        }
    }
}