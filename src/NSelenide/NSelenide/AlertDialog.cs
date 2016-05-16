using System;
using NSelenide.Impl;
using OpenQA.Selenium;

namespace NSelenide
{
    public class AlertDialog
    {
        private readonly int timeout = 0;

        public AlertDialog(int timeout)
        {
            this.timeout = timeout;
        }
        public void Accept()
        {
            try
            {
                WaitAlert().Accept();
            }
            catch (Exception)
            {
                
            }
        }

        public string Text
        {
            get
            {
                return WaitAlert().Text;
            }
        }
        public void Cancel()
        {
            try
            {
                WaitAlert().Accept();
            }
            catch (Exception)
            {

            }
        }

        private IAlert WaitAlert()
        {
            var endDate = DateTime.Now.AddMilliseconds(this.timeout > 0 ? this.timeout : Settings.Timeout);
            NoAlertPresentException lastError;
            do
            {
                try
                {
                    IAlert alert = WebDriverRunner.GetWebDriver().SwitchTo().Alert();
                    var text = alert.Text; // check that alert actually exists
                    return alert;
                }
                catch (NoAlertPresentException e)
                {
                    lastError = e;
                    System.Threading.Thread.Sleep(Settings.Pooling);
                }
            } while (DateTime.Now <= endDate);

            throw lastError;
        }

        public void ShouldBePresent()
        {
            WaitAlert();
        }
    }

}
