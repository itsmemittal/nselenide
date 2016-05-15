namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    public class VisibleCondition : ICondition
    {
        public bool Apply(IWebElement element)
        {
            return element.Displayed;
        }

        public string ActualValue(IWebElement element)
        {
            return element.Displayed ? "visible" : "not visible";
        }

        public override string ToString()
        {
            return "visible";
        }
    }
}