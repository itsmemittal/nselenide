namespace NSelenide
{
    using System;
    using System.Linq;

    using Exceptions;
    using Impl;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Interactions;
    public class PageElement
    {
        private readonly ByHelper locator;
        private readonly int timeoutMillisecond;
        private readonly ISearchContext parent;
        private readonly int index;

        public PageElement(ISearchContext parent, ByHelper locator,int index)
        {
            this.locator = locator;
            this.timeoutMillisecond = Settings.Timeout;
            this.parent = parent;
            this.index = index;
        }

        public PageElement(ISearchContext parent, ByHelper locator)
        {
            this.locator = locator;
            this.timeoutMillisecond = Settings.Timeout;
            this.parent = parent;
        }
        
        public void Click()
        {
            Element.Click();
        }

        public void DoubleClick()
        {
            Actions.DoubleClick(Element).Perform();
        }

        public PageElement RightClick()
        {
            Actions.ContextClick(Element).Perform();
            return this;
        }

        public PageElement SetValue(string value)
        {
            var element = Element;
            if (Settings.FastSet)
            {
                ((IJavaScriptExecutor)WebDriverRunner.GetWebDriver()).ExecuteScript(string.Format("arguments[0].value='{0}'",value));
            }
            else
            {
                element.Clear();
                element.SendKeys(value);
            }
 
            return this;
        }

        public string GetValue()
        {
            return GetAttribute("value");
        }

        public PageElement Select(Selection mode, params string[] values)
        {
            var Select = new SelectElement(Element);
            switch (mode)
            {
                case Selection.Text:
                {
                    foreach (var value in values)
                    {
                        Select.SelectByText(value);
                    }

                    break;
                }

                case Selection.Index:
                {
                    foreach (var value in values)
                    {
                        Select.SelectByIndex(int.Parse(value));
                    }
                    
                    break;
                }

                case Selection.Value:
                {
                    foreach (var value in values)
                    {
                        Select.SelectByValue(value);
                    }
                    
                    break;
                }
            }

            return this;
        }

        public PageElement DeSelect(Selection mode, params string[] values)
        {
            var Select = new SelectElement(Element);
            switch (mode)
            {
                case Selection.Text:
                    {
                        foreach (var value in values)
                        {
                            Select.DeselectByText(value);
                        }

                        break;
                    }

                case Selection.Index:
                    {
                        foreach (var value in values)
                        {
                            Select.DeselectByIndex(int.Parse(value));
                        }

                        break;
                    }

                case Selection.Value:
                    {
                        foreach (var value in values)
                        {
                            Select.DeselectByValue(value);
                        }

                        break;
                    }
            }

            return this;
        }

        public PageElement DeSelectAll()
        {
            var Select = new SelectElement(Element);
            Select.DeselectAll();
            return this;
        }

        public string GetSelectedText()
        {
            var Select = new SelectElement(Element);
            return Select.SelectedOption.Text;
        }

        public string GetSelectedValue()
        {
            var Select = new SelectElement(Element);
            return Select.SelectedOption.GetAttribute("value");
        }

        public string GetAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }

        public bool Displayed
        {
            get
            {
                return Is(ExpectedConditions.Visible);
            }
        }

        public bool Enabled
        {
            get
            {
                return Is(ExpectedConditions.Enabled);
            }
        }

        public string InnerHtml
        {
            get
            {
                return GetAttribute("innerHTML");
            }
        }

        public string GetDataAttribute(string attribute)
        {
            return GetAttribute("data-" + attribute);
        }

        public string InnerText
        {
            get
            {
                return GetAttribute("innerText");
            }
        }

        public PageElement Hover()
        {
            Actions.MoveToElement(Element).Perform();
            return this;
        }

        public PageElement PressEnter()
        {
            Element.SendKeys(Keys.Enter);
            return this;
        }

        public PageElement PressEscape()
        {
            Element.SendKeys(Keys.Escape);
            return this;
        }

        public PageElement PressTab()
        {
            Element.SendKeys(Keys.Tab);
            return this;
        }

        public PageElement Find(string selector)
        {
            return new PageElement(Element, ByHelper.Create(selector));
        }

        public PageElement Find(ByHelper byhelper)
        {
            return new PageElement(Element, byhelper);
        }

        public PageElementCollection FindAll(string selector)
        {
            return new PageElementCollection(Element, ByHelper.Create(selector));
        }

        public PageElementCollection FindAll(ByHelper byhelper)
        {
            return new PageElementCollection(Element, byhelper);
        }

        public PageElement Parent()
        {
            return new PageElement(Element, ByHelper.XPath(".."));
        }

        //-------------------------Verification--------------------------------------------
        public bool Is(params ICondition[] conditions)
        {
            try
            {
                CheckConditions("be", conditions);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Has(params ICondition[] conditions)
        {
            try
            {
                CheckConditions("have", conditions);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public PageElement ShouldBe(params ICondition[] conditions)
        {
            return ApplyConditions("be", conditions);
        }

        public PageElement ShouldNotBe(params ICondition[] conditions)
        {
            return ApplyConditions("not be", conditions);
        }

        public PageElement ShouleHave(params ICondition[] conditions)
        {
            return ApplyConditions("have", conditions);
        }

        public PageElement ShouldNotHave(params ICondition[] conditions)
        {
            return ApplyConditions("not have", conditions);
        }

        private PageElement ApplyConditions(string prefix, params ICondition[] conditions)
        {
            CheckConditions(prefix, conditions);
            return this;
        }

        private IWebElement CheckCondition(string prefix, ICondition condition, int timeout = 0)
        {
            return CheckConditions(prefix, new[] {condition}, timeout);
        }

        private IWebElement CheckConditions(string prefix, ICondition[] conditions, int timeout = 0)
        {
            var endDate = DateTime.Now.AddMilliseconds(timeout > 0 ? timeout : timeoutMillisecond);
            Exception lastError = null;
            IWebElement targetElement = null;
            ICondition failedCondition = null;
            WebDriverRunner.GetWebDriver().SwitchTo().DefaultContent();
            do
            {
                try
                {
                    targetElement = getWebElement();
                    if (targetElement == null)
                    {
                        var message = string.Format("Failed to find element '{0}' using [ {1} ].",
                            this.locator.LocatorName, this.locator.Locator);
                        throw new NoSuchElementException(message);
                    }
                    if (conditions != null)
                    {
                        IWebElement element = targetElement;
                        foreach (var condition in conditions.Where(condition => !condition.Apply(element)))
                        {
                            failedCondition = condition;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lastError = ex;
                    System.Threading.Thread.Sleep(Settings.Pooling);
                }

            } while (DateTime.Now <= endDate);

            if (targetElement == null && lastError != null)
            {
                throw lastError;
            }

            if (targetElement != null && failedCondition != null)
            {
                throw new ElementShouldException(prefix, failedCondition, this.locator.LocatorName, targetElement,
                    lastError);
            }

            return targetElement;
        }

        private ISearchContext GetSearchContext()
        {
            return this.parent ?? WebDriverRunner.GetWebDriver();
        }

        private IWebElement getWebElement()
        {
            ISearchContext context = GetSearchContext();
            var elements = context.FindElements(this.locator.Locator);
            if (elements.Count <= 0) return null;
            return index == 0 ? elements.First() : elements.Skip(index - 1).First();
        }

        private IWebElement Element
        {
            get
            {
                return CheckCondition("be", ExpectedConditions.Clickable);
            }

        }

        private static Actions Actions
        {
            get
            {
                return new Actions(WebDriverRunner.GetWebDriver());
            }

        }

    }

    public enum Selection
    {
        Text,
        Value,
        Index
    }


}
