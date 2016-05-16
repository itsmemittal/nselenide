using NSelenide;
using NUnit.Framework;

namespace NSelenideTest
{
    [TestFixture]
    public class Test
    {
        private DOM dom = new DOM();

        [OneTimeSetUp]
        public void AlertSetup()
        {
            dom.Open("file:///C:/Users/Isu/Desktop/songs/NSelenide/NSelenide/NSelenideTest/Resource/sample.html");
            dom.Element("ul").Click();
        }

        [Test]
        public void AlertAcceptTest()
        {
            dom.Element("ul").Click();
            dom.Alert().Accept();
        }

        [Test]
        public void AlertPresenceTest()
        {
            dom.Element("li").Click();
            dom.Alert().ShouldBePresent();
        }

    }
}
