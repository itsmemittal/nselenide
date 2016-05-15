namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    public class NotCondition : ICondition
    {
        private readonly ICondition condition;

        public NotCondition(ICondition condition)
        {
            this.condition = condition;
        }

        public bool Apply(IWebElement element)
        {
            return !this.condition.Apply(element);
        }

        public override string ToString()
        {
            return this.condition.ToString();
        }

        public string ActualValue(IWebElement element)
        {
            return this.condition.ActualValue(element);
        }
    }
}