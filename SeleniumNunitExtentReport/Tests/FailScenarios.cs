using NUnit.Framework;
using SeleniumNunitExtentReport.Config;

namespace SeleniumNunitExtentReport.Tests
{
    public class FailScenarios : BaseClass
    {

        [Test]

        public void FailTest()
        {
            Driver.Url = "http://google.com";
            Assert.AreEqual(Driver.Title, "Journey");
        }
    }
}
