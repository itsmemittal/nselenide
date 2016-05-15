using System;

namespace NSelenide.Exceptions
{
    using OpenQA.Selenium;

    public class ElementShouldException : Exception
    {
        public ElementShouldException(string prefix, ICondition condition, string locatorName, IWebElement lastElement, Exception lastError)
            : base(BuildErrorMessage(prefix, condition, locatorName, lastElement, lastError))
        {
        }

        private static string BuildErrorMessage(string prefix, ICondition condition, string locatorName, IWebElement lastElement, Exception lastError)
        {
            return string.Format("Elment Should {0} \"{1}\" for [ {2} ] \n Actual : {4} {3}", prefix, condition, locatorName, lastError, condition.ActualValue(lastElement));
        }
    }
}
