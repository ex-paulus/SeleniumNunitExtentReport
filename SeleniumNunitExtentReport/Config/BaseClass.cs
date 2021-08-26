using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using SeleniumNunitExtentReport.Tests;

namespace SeleniumNunitExtentReport.Config
{

    public class BaseClass
    {

        public IWebDriver Driver;

        public ExtentTest Test;

        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();
            Test = SetupClass.Extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? string.Empty
                : string.Format("{ 0}", TestContext.CurrentContext.Result.StackTrace);

            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    var time = DateTime.Now;
                    var fileName = TestContext.CurrentContext.Test.Name;
                    var screenShotPath = Capture(Driver, fileName);
                    Test.Log(Status.Fail, "Fail");
                    Test.Log(Status.Fail, "Snapshot below: " + Test.AddScreenCaptureFromPath(screenShotPath));
                    break;

                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;

                case TestStatus.Skipped:

                    logstatus = Status.Skip;
                    break;

                default:

                    logstatus = Status.Pass;
                    break;

            }

            Test.Log(logstatus, "Test ended with" + logstatus + stacktrace);
            Driver.Quit();
        }

        public static string Capture(IWebDriver driver, String screenShotName)
        {
            var ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;

            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");

            var finalpth = pth.Substring(0, pth.LastIndexOf("bin", StringComparison.Ordinal)) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;

            screenshot.SaveAsFile(localpath + screenShotName + ".png");
            return localpath;
        }

    }
}