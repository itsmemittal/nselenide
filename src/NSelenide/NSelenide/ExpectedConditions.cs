namespace NSelenide
{
    using System;

    using NSelenide.Impl.Conditions;

    public static class ExpectedConditions
    {
        public static ICondition Visible
        {
            get
            {
                return new VisibleCondition();
            }
        }

        public static ICondition Clickable
        {
            get
            {
                return new ClickableCondition();
            }
        }

        public static ICondition Disabled
        {
            get
            {
                return new DisableCondition();
            }
        }

        public static ICondition Enabled
        {
            get
            {
                return new EnableCondition();
            }
        }

        public static ICondition Selected
        {
            get
            {
                return new ElementSelectedCondition();
            }
        }

        public static ICondition Empty
        {
            get
            {
                return new EmptyCondition();
            }
        }

        public static ICondition Exists
        {
            get
            {
                return new ExistsCondition();
            }
        }

        public static ICondition ReadOnly
        {
            get
            {
                return Attribute("readonly");
            }
        }

        public static ICondition Not(ICondition condition)
        {
            return new NotCondition(condition);
        }

        public static ICondition Text(string expectedText)
        {
            return new TextCondition(expectedText);
        }

        public static ICondition ExactText(string expectedText)
        {
            return new TextCondition(expectedText);
        }

        public static ICondition TagName(string expectedTagName)
        {
            return new TagCondition(expectedTagName);
        }

        public static ICondition Attribute(string attribute)
        {
            return new AttributeCondition(attribute, string.Empty);
        }

        public static ICondition Attribute(string attribute,string attributeValue)
        {
            return new AttributeCondition(attribute, attributeValue);
        }

    }
}