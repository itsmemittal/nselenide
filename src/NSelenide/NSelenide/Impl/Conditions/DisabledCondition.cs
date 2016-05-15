namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    public class DisableCondition : ICondition
    {
        public bool Apply(IWebElement element)
        {
            return !element.Enabled;
        }

        public string ActualValue(IWebElement element)
        {
            return element.Enabled ? "not disabled" : "disabled";
        }

        public override string ToString()
        {
            return "disabled";
        }
    }
}