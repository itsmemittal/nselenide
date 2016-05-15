namespace NSelenide.Impl.Conditions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class TextCondition : ICondition
    {
        private readonly string expectedText;

        public TextCondition(string expectedText)
        {
            this.expectedText = expectedText;
        }

        public bool Apply(IWebElement element)
        {
            return this.GetText(element).Contains(this.expectedText);
        }

        public string ActualValue(IWebElement element)
        {
            return this.GetText(element);
        }

        public override string ToString()
        {
            return string.Format("Text : {0}", this.expectedText);
        }

        private string GetText(IWebElement element)
        {
            if (element.TagName == "input")
            {
                return element.GetAttribute("value");
            }

            if (element.TagName == "select")
            {
                var selectItem = new SelectElement(element);
                return selectItem.SelectedOption.Text;
            }

            return element.Text;
        }
    }
}
