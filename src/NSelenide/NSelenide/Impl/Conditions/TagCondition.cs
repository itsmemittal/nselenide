namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    public class TagCondition : ICondition
    {
        private readonly string expectedTagName;

        public TagCondition(string expectedTagName)
        {
            this.expectedTagName = expectedTagName;
        }

        public string Name { get; private set; }

        public bool Apply(IWebElement element)
        {
            return element.TagName == this.expectedTagName;
        }

        public string ActualValue(IWebElement element)
        {
            throw new System.NotImplementedException();
        }
    }
}