namespace NSelenide
{
    using System;
    using System.Linq.Expressions;

    using OpenQA.Selenium;

    public class ByHelper
    {
        public By Locator { get; set; }

        public string LocatorName { get; set; }

        public static ByHelper Id(string id)
        {
            return new ByHelper { Locator = By.Id(id), LocatorName = id };
        }

        public static ByHelper CssClass(string cssClass)
        {
            return new ByHelper { Locator = By.ClassName(cssClass), LocatorName = cssClass };
        }

        public static ByHelper CssSelector(string cssSelector)
        {
            return new ByHelper { Locator = By.CssSelector(cssSelector), LocatorName = cssSelector };
        }

        public static ByHelper LinkText(string linkText)
        {
            return new ByHelper { Locator = By.LinkText(linkText), LocatorName = linkText };
        }

        public static ByHelper XPath(string xpath)
        {
            return new ByHelper { Locator = By.XPath(xpath), LocatorName = xpath };
        }

        public static ByHelper Name(string name)
        {
            return new ByHelper { Locator = By.Name(name), LocatorName = name };
        }

        public static ByHelper Tag(string tag)
        {
            return new ByHelper { Locator = By.TagName(tag), LocatorName = tag };
        }

        public static ByHelper Id(Expression<Func<string>> e)
        {
            var value = GetPropertyValue(e);
            return new ByHelper { Locator = By.Id(value), LocatorName = GetPropertyName(e) };
        }

        public static ByHelper CssClass(Expression<Func<string>> e)
        {
            var value = GetPropertyValue(e);
            return new ByHelper { Locator = By.ClassName(value), LocatorName = GetPropertyName(e) };
        }

        public static ByHelper CssSelector(Expression<Func<string>> e)
        {
            var value = GetPropertyValue(e);
            return new ByHelper { Locator = By.CssSelector(value), LocatorName = GetPropertyName(e) };
        }

        public static ByHelper LinkText(Expression<Func<string>> e)
        {
            var value = GetPropertyValue(e);
            return new ByHelper { Locator = By.LinkText(value), LocatorName = GetPropertyName(e) };
        }

        public static ByHelper XPath(Expression<Func<string>> e)
        {
            var value = GetPropertyValue(e);
            return new ByHelper { Locator = By.XPath(value), LocatorName = GetPropertyName(e) };
        }

        public static ByHelper Name(Expression<Func<string>> e)
        {
            var value = GetPropertyValue(e);
            return new ByHelper { Locator = By.Name(value), LocatorName = GetPropertyName(e) };
        }

        public static ByHelper Tag(Expression<Func<string>> e)
        {
            var value = GetPropertyValue(e);
            return new ByHelper { Locator = By.TagName(value), LocatorName = GetPropertyName(e) };
        }

        private static string GetPropertyValue(Expression<Func<string>> e)
        {
            var member = e.Compile();
            return member();
        }

        private static string GetPropertyName(Expression<Func<string>> e)
        {
            var member = (MemberExpression)e.Body;
            return member.Member.Name;
        }

        public static ByHelper Create(string selector)
        {
            var trimSelector = selector.Trim();
            var multiselectors = trimSelector.IndexOf(" ", StringComparison.Ordinal) != -1;
            if (trimSelector.StartsWith("#") && trimSelector.Length > 1 && !multiselectors)
            {
                var id = trimSelector.Substring(1, trimSelector.Length-1);
                return Id(id);
            }

            if (trimSelector.StartsWith(".") && trimSelector.Length > 1 && !multiselectors)
            {
                var id = trimSelector.Substring(1, trimSelector.Length-1);
                return CssClass(id);
            }
            return CssSelector((selector));
        }
    }
}
