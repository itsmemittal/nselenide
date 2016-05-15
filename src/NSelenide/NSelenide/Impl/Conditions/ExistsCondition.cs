namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    internal class ExistsCondition : ICondition
    {
        public bool Apply(IWebElement element)
        {
            var result = element.Displayed;
            return true;
        }

        public string ActualValue(IWebElement element)
        {
            return element.Displayed ? "exists" : "not exists";
        }

        public override string ToString()
        {
            return "exists";
        }
    }
}
