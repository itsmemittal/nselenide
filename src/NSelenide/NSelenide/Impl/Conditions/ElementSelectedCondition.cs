namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    public class ElementSelectedCondition : ICondition
    {
        public bool Apply(IWebElement element)
        {
            return element.Selected;
        }

        public string ActualValue(IWebElement element)
        {
            return element.Selected ? "selected" : "not selected";
        }

        public override string ToString()
        {
            return "selected";
        }
    }
}