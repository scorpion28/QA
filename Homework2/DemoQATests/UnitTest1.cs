using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQATests;

public class Tests
{
    IWebDriver Driver { get; set; }

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
    }

    [Test]
    public void Test1()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com");

        var cards = Driver.FindElements(By.XPath("//div[@class=\"card mt-4 top-card\"]"));
    }

    [Test]
    public void Test2()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/forms");

        var practiceFormButton = 
            Driver.FindElement(By.XPath("//span[contains(text(), \"Practice Form\")]/.."));
    }
    
    [Test]
    public void Test3()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/menu");

        var mainItem1 = Driver.FindElement(By.XPath("//*[@id=\"nav\"]/li[1]/a"));
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}