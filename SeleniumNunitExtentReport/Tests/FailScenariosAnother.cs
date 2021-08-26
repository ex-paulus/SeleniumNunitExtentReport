using NUnit.Framework;
using SeleniumNunitExtentReport.Config;

namespace SeleniumNunitExtentReport.Tests
{
    public class FailScenariosAnother : BaseClass
    {
        [Test]
        public void FailTestAgain()
        {
            Driver.Url = "http://google.com";
            Assert.Fail("Fail once again!");
        }
    }
}
