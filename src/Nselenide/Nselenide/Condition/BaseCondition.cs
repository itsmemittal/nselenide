using OpenQA.Selenium;

namespace Nselenide.ExpectedConditions
{
    public static class Conditions
    {
        public static readonly ICondition Visible = new VisibleCondiion();

        public static ICondition Text(string expectedText)
        {
            return new TextCondition(expectedText);
        }
    }

    public interface ICondition
    {
        string Name { get; }
        bool Apply(IWebElement element);
        string ActualValue(IWebElement element);
    }

    public class VisibleCondiion : ICondition
    {
        public string Name
        {
            get { return "visible"; }
        }

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
            return Name;
        }

    }

    public class TextCondition : ICondition
    {
        private readonly string expectedText;

        public TextCondition(string expectedText)
        {
            this.expectedText = expectedText;
        }

        public string Name
        {
            get { return "text"; }
        }

        public bool Apply(IWebElement element)
        {
            return element.Text.Contains(expectedText);
        }

        public override string ToString()
        {
            return Name;
        }


        public string ActualValue(IWebElement element)
        {
            return element.Text;
        }
    }
}
