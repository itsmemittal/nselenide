namespace NSelenide
{
    using OpenQA.Selenium;

    public interface ICondition
    {
        bool Apply(IWebElement element);

        string ActualValue(IWebElement element);
    }
}
