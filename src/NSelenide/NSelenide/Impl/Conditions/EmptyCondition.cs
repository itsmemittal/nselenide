namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    public class EmptyCondition : ICondition
    {
        public bool Apply(IWebElement element)
        {
            return element.GetAttribute("innerHTML").Length <= 0;
        }

        public string ActualValue(IWebElement element)
        {
            return element.GetAttribute("innerHTML");
        }

        public override string ToString()
        {
            return "empty";
        }

    }
}
