using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;

namespace SeleniumNunitExtentReport.Tests
{
    [SetUpFixture]
    public class SetupClass
    {
        public static ExtentReports Extent;

        [OneTimeSetUp]

        protected void Setup()
        {
            Extent = new ExtentReports();
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", string.Empty);
            var di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
            var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");

            Extent.AddSystemInfo("Environment", "Journey of Quality");
            Extent.AddSystemInfo("User Name", "Neha");
            Extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            Extent.Flush();
        }
    }
}