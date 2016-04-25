using System;
using Nselenide.Exceptions;
using Nselenide.ExpectedConditions;
using OpenQA.Selenium;

namespace Nselenide
{
    public class SelenideElement
    {
        private readonly ISearchContext parent;
        private readonly By locator;
        public SelenideElement(ISearchContext parent,By locator)
        {
            this.parent = parent;
            this.locator = locator;
        }

        private IWebElement Element
        {
            get
            {
                var context = parent ?? WebDriverRunner.GetWebDriver();
                return context.FindElement(locator);
            }
        }

        public SelenideElement Click()
        {
            IWebElement element = CheckCondition("be", null, Conditions.Visible, false);
            element.Click();
            return this;    
        }

        //public SelenideElement WaitUntil(Func<IWebElement, bool> condition)
        //{
        //    DateTime dateTimeTimeout = DateTime.Now.Add(TimeSpan.FromSeconds(Configuration.Timeout));
        //    bool passed = false;
        //    while (DateTime.Now < dateTimeTimeout)
        //    {
        //        try
        //        {
        //            IWebElement _element = GetElement();
        //            if (condition(_element))
        //            {
        //                element = _element;
        //                passed = true;
        //                break;
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //        }
        //        System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(Configuration.Pooling));
        //    }

        //    if (!passed)
        //    {
        //        throw new Exception("Wait failed");
        //    }

        //    return this;
        //}

        private IWebElement CheckCondition(string prefix, string message, ICondition condition, bool invert)
        {
            IWebElement element = null;
            Exception lastError = null;
            try
            {
                element = Element;
                if (element !=null && condition.Apply(element))
                {
                    return element;
                }
            }
            catch (Exception e)
            {
                lastError = e;
            }

            if (element == null && lastError != null)
            {
                throw lastError;
            }
            return element;
            //throw new NotImplementedException();

            //else
            //{
            //    throw new ElementShould(locator.ToString(), prefix, message, condition, element, lastError);    
            //}
            //return null;

            //throw new Exception("Dfdfd");

        }

    }

    public interface ISelenideElement
    {
        
    }
}