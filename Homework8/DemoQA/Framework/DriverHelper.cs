using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQA.Framework;

public class DriverHelper
{
    public static IWebDriver GetDriver()
    {
        //some logic to choose driver and options
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--force-device-scale-factor=0.9");

        var driver = new ChromeDriver(options);

        return driver;
    }

    public static string MakeScreenshot(IWebDriver driver, string testName)
    {
        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        string screenshotsFolder =
            Path.Combine(projectDirectory ?? Directory.GetCurrentDirectory(), @"Reports/Screenshots");

        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

        var dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        var screenshotName = $"{testName}-{dateTimeStr}.png";

        var screenshotPath = Path.Combine(screenshotsFolder, screenshotName);

        if (!Directory.Exists(screenshotsFolder))
        {
            Directory.CreateDirectory(screenshotsFolder);
        }

        screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

        return screenshotPath;
    }
}