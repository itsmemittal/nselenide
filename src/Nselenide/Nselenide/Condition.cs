using System;
using OpenQA.Selenium;

namespace Nselenide
{
    public class Condition
    {
        public static Func<IWebElement, bool> Visible = element => element.Displayed;
        public static Func<IWebElement, string, bool> Text = (element, s) => element.Text == s;
        public static Func<IWebElement,bool> Exists = delegate(IWebElement element)
        {
            var elem = element.Displayed;
            return true;
        };

        public static Func<IWebElement, bool> Present = Exists;

        public static Func<IWebElement, bool> Hidden = delegate(IWebElement element)
        {
            try
            {
                return !element.Displayed;
            }
            catch (StaleElementReferenceException elementHasDisappeared)
            {
                return true;
            }
        };

        public static Func<IWebElement, string, string, bool> HasAttribute =
            (element, attributeName, expectedAttributeValue) =>
                expectedAttributeValue.Equals(GetAttributeValue(element, attributeName));

        public static Func<IWebElement,string,bool> Attribute =
            (element, attributeName) => element.GetAttribute(attributeName) != null;


        public static Func<IWebElement, bool> ReadOnly = element => Attribute(element, "readonly"); 














        private static string GetAttributeValue(IWebElement element, String attributeName)
        {
            String attr = element.GetAttribute(attributeName);
            return attr == null ? "" : attr.Trim();
        }
    }

    //public class Conditions
    //{
    //    public static Func<IWebElement, bool> Visible = element => element.Displayed;

    //    public static Func<IWebElement, bool> Enabled = element => element.Enabled;

    //    public static Func<IWebElement, bool> Clickable = element => element.Enabled && element.Displayed;

    //    public static Func<IWebElement, bool> Exists = CheckExists;

    //    public static Func<IWebElement, bool> Present = CheckExists;

    //    public static Func<IWebElement, bool> Hidden = CheckHidden;

    //    public static Func<string, bool> ReadOnly = CheckAttribute(IWebElement);

    //    public static Func<IWebElement, string, bool> HasAttribute = CheckAttribute;
 

    //    private static bool CheckAttribute(IWebElement element, string attributeName)
    //    {
    //        return element.GetAttribute(attributeName) != null;
    //    }

    //    private static bool CheckHidden(IWebElement element)
    //    {
    //        try
    //        {
    //            return !element.Displayed;
    //        }
    //        catch (StaleElementReferenceException elementSaElementReferenceException)
    //        {
    //            return true;
    //        }
    //    }

    //    private static bool CheckExists(IWebElement element)
    //    {
    //        var displayed = element.Displayed;
    //        return true;
    //    }

    //}
}
