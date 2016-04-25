using System;
using OpenQA.Selenium;
using Nselenide.ExpectedConditions;

namespace Nselenide.Exceptions
{
    public class ElementShould : Exception
    {
        public ElementShould(string criteria, string prefix, string message, ICondition expectedCondition, IWebElement element,
            Exception lastError) : base(BuildMessage(criteria, prefix, message, expectedCondition, element),lastError)
        {

        }

        private static string BuildMessage(string criteria, string prefix, string message, ICondition expectedCondition, IWebElement element)
        {
            var actualValue = string.Format("Actual Value: {0}", expectedCondition.ActualValue(element));
            var because = (message != null ? " because " + message : "");
            return string.Format("Element should {0} {1} {2} \\n Element : {3} {4}.", prefix, expectedCondition, because,
                element, actualValue);
        }
        
    }
}
