using System;
using OpenQA.Selenium;

namespace Nselenide
{
    public class SelenideElement
    {
        private IWebElement element;
        private readonly ISearchContext parent;
        private readonly By locator;
        public SelenideElement(ISearchContext parent,By locator)
        {
            this.parent = parent;
            this.locator = locator;
        }

       
        private IWebElement GetElement()
        {
            if (element != null) return element;
            var context = parent ?? WebDriverRunner.GetWebDriver();
            return context.FindElement(locator);
        }

        public SelenideElement Value(string value)
        {
            WaitUntil(Condition.Visible);
            element.SendKeys(value);
            return this;
        }

        public SelenideElement Click()
        {
            WaitUntil(Condition.Visible);
            element.Click();
            return this;
        }

        public SelenideElement DoubleClick()
        {
            throw new NotImplementedException();
        }

        public SelenideElement ContextClick()
        {
            throw new NotImplementedException();
        }

        public SelenideElement DragDropTo()
        {
            throw new NotImplementedException();
        }

        public SelenideElement Exists()
        {
            throw new NotImplementedException();
        }

        public SelenideElement Find()
        {
            throw new NotImplementedException();
        }

        public SelenideElement FindAll()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetAtribue()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetInnerHtml()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetInnerText()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetParent()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetSelectedOption()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetSelectedText()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetSelectedValue()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetText()
        {
            throw new NotImplementedException();
        }

        public SelenideElement GetWrappedElement()
        {
            throw new NotImplementedException();
        }

        public SelenideElement Hover()
        {
            throw new NotImplementedException();
        }





        public SelenideElement PressEnter()
        {
            throw new NotImplementedException();
        }









        public SelenideElement Enter()
        {
            throw new NotImplementedException();
        }

        public SelenideElement Escape()
        {
            throw new NotImplementedException();
        }

        public SelenideElement ScrollTo()
        {
            throw new NotImplementedException();
        }

        public SelenideElement SelectOptionByText()
        {
            throw new NotImplementedException();
        }

        public SelenideElement SelectOptionByValue()
        {
            throw new NotImplementedException();
        }

        public SelenideElement SelectRadio()
        {
            throw new NotImplementedException();
        }

        public SelenideElement SetSelected()
        {
            throw new NotImplementedException();
        }

        public SelenideElement SetValue()
        {
            throw new NotImplementedException();
        }

        public SelenideElement TakeScreenShot()
        {
            throw new NotImplementedException();
        }

        public SelenideElement Val()
        {
            throw new NotImplementedException();
        }






        public SelenideElement WaitUntil(Func<IWebElement, bool> condition, int timeoutMilisecond)
        {
            throw new NotImplementedException();
        }

        public SelenideElement WaitUntil(Func<IWebElement, bool> condition)
        {
            DateTime dateTimeTimeout = DateTime.Now.Add(TimeSpan.FromSeconds(Configuration.Timeout));
            bool passed = false;
            while (DateTime.Now < dateTimeTimeout)
            {
                try
                {
                    IWebElement _element = GetElement();
                    condition(_element);
                    element = _element;
                    passed = true;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(Configuration.Pooling));
            }

            if (!passed)
            {
                throw new Exception("Wait failed");
            }

            return this;
        }

        public SelenideElement ShouldHave(Condition condition)
        {
         throw new NotImplementedException();   
        }

        public SelenideElement ShouldNotHave(Condition condition)
        {
            throw new NotImplementedException();
        }

        public SelenideElement ShouldBe(Condition condition)
        {
            throw new NotImplementedException();
        }

        public SelenideElement ShouldNotBe(Condition condition)
        {
            throw new NotImplementedException();
        }

        public SelenideElement Should(Condition condition)
        {
            throw new NotImplementedException();
        }

        public SelenideElement ShouldNot(Condition condition)
        {
            throw new NotImplementedException();
        }

    }
}