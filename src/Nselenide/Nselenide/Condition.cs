using System;
using System.Runtime.InteropServices.WindowsRuntime;
using OpenQA.Selenium;

namespace Nselenide
{
    public class Condition
    {
        public static readonly Func<IWebElement,bool> Visible = VisibleFunc;

        public static readonly Func<IWebElement,bool> Present = PresentFunc;

        public static readonly Func<IWebElement,bool> Hidden = HiddenFunc;

        public static Func<IWebElement,string,string,bool> HasAttribute = HasAttributeFunc;
        
        public static Func<IWebElement,string,bool> Attribute = AttributeFunc;

        public static readonly Func<IWebElement, string, string, bool> Attributevalue = AttributeValueFunc;

        public static readonly  Func<IWebElement,bool> ReadOnly = ReadOnlyFunc;

        public static readonly Func<IWebElement,string,bool> HasValue = HasValueFunc;

        public static readonly Func<IWebElement,bool> Enabled = EnabledFunc;

        public static readonly  Func<IWebElement,bool> Disabled = DisabledFunc;

        public static readonly Func<IWebElement,bool> Selected = SelectedFunc;

        private static bool SelectedFunc(IWebElement webElement)
        {
            return webElement.Selected;
        }

        private static bool DisabledFunc(IWebElement webElement)
        {
            return !webElement.Enabled;
        }

        private static bool EnabledFunc(IWebElement webElement)
        {
            return webElement.Enabled;
        }

        private static bool HasValueFunc(IWebElement webElement, string expectedValue)
        {
           return expectedValue.Equals(GetAttributeValue(webElement, "value"));
        }
        
        private static bool VisibleFunc(IWebElement webElement)
        {
            return webElement.Displayed;
        }

        private static bool PresentFunc(IWebElement webElement)
        {
            var e = webElement.Displayed;
            return true;
        }

        private static bool HiddenFunc(IWebElement webElement)
        {
            try
            {
                return !webElement.Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        private static bool HasAttributeFunc(IWebElement webElement, string s, string arg3)
        {
            return AttributeValueFunc(webElement, s, arg3);
        }

        private static bool AttributeFunc(IWebElement webElement, string attributeName)
        {
            return webElement.GetAttribute(attributeName) != null;
        }

        private static bool AttributeValueFunc(IWebElement webElement, string attributeName, string attributeValue)
        {
            return attributeValue.Equals(GetAttributeValue(webElement, attributeName));
        }

        private static string GetAttributeValue(IWebElement element, String attributeName)
        {
            String attr = element.GetAttribute(attributeName);
            return attr == null ? "" : attr.Trim();
        }

        private static bool ReadOnlyFunc(IWebElement webElement)
        {
            return AttributeFunc(webElement, "readonly");
        }
    }

}
