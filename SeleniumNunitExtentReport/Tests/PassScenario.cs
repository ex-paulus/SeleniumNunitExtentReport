using NUnit.Framework;
using SeleniumNunitExtentReport.Config;

namespace SeleniumNunitExtentReport.Tests
{
    public class PassScenarios : BaseClass
    {
        [Test]
        public void PassTest()
        {
            Driver.Url = "http://google.com";
            Assert.AreEqual(Driver.Title, "Google");
        }
    }
}