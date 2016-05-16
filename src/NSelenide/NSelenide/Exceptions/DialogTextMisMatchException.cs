using System;

namespace NSelenide.Exceptions
{
    public class DialogTextMisMatchException : Exception
    {
        public DialogTextMisMatchException(string actualText, string expectedText):base("\nActual: " + actualText +
        "\nExpected: " + expectedText)
        {
            
        }
    }
}
