using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DemoQA.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace DemoQA.Tests;

public class BaseTest
{
    protected ExtentReports reportManager;
    protected ExtentTest extentTest;
    protected IWebDriver Driver { get; set; }
    protected PageList Pages { get; private set; }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        reportManager = new ExtentReports();

        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        var reportsPath = Path.Combine(projectDirectory ?? Directory.GetCurrentDirectory(), @"Reports\TestReport.html");

        var htmlReporter = new ExtentHtmlReporter(reportsPath);
        reportManager.AttachReporter(htmlReporter);
    }

    [SetUp]
    public void Setup()
    {
        Driver = DriverHelper.GetDriver();
        Driver.Manage().Window.Maximize();
        
        Pages = new PageList(Driver);

        extentTest = reportManager.CreateTest(TestContext.CurrentContext.Test.FullName);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        reportManager.Flush();
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                extentTest.Log(Status.Pass);
            }
            else
            {
                var path = DriverHelper.MakeScreenshot(Driver, TestContext.CurrentContext.Test.MethodName);
                extentTest.AddScreenCaptureFromPath(path);
                extentTest.Log(Status.Fail);
            }
        }
        finally
        {
            Driver.Quit();
        }
    }
}