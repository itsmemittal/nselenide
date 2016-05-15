using System.Collections.Generic;
using OpenQA.Selenium;

namespace NSelenide
{
    public class PageElementCollection
    {
        private readonly ByHelper locator;
        private readonly ISearchContext parent;
        
        public PageElementCollection(ISearchContext context, ByHelper locator)
        {
            this.locator = locator;
            this.parent = context;
        }

        private ISearchContext GetSearchContext()
        {
            return this.parent ?? WebDriverRunner.GetWebDriver();
        }

        private IReadOnlyCollection<IWebElement> getWebElements()
        {
            ISearchContext context = GetSearchContext();
            var elements = context.FindElements(this.locator.Locator);
            return elements;
        }

        public PageElement First()
        {
            return new PageElement(parent, locator, 0);
        }

        public PageElement Last()
        {
            return new PageElement(parent, locator, Size() - 1);
        }

        public PageElement Get(int index)
        {
            return new PageElement(parent, locator, index);
        }

        public int Size()
        {
            return getWebElements().Count;
        }
    }
}
