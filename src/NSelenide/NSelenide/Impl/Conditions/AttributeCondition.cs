namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;

    public class AttributeCondition : ICondition
    {
        private readonly string expectedAttribute;
        private readonly string expectedAttributeval;

        public AttributeCondition(string attribute, string attributeValue)
        {
            this.expectedAttribute = attribute;
            this.expectedAttributeval = attributeValue;
        }

        public bool Apply(IWebElement element)
        {
            var expected = element.GetAttribute(this.expectedAttribute);
            if (string.IsNullOrEmpty(this.expectedAttributeval))
            {
                return expected != null;
            }

            return expected != null && expected.Equals(this.expectedAttributeval);
        }

        public string ActualValue(IWebElement element)
        {
            var expected = element.GetAttribute(this.expectedAttribute);
            if (expected != null)
            {
                return "attribute" + " " + this.expectedAttribute + '=' + expected;
            }

            return "attribute " + this.expectedAttribute;

        }

        public override string ToString()
        {
            return "attribute" + " " + this.expectedAttribute + '=' + this.expectedAttributeval;
        }
    }
}