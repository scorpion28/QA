using OpenQA.Selenium;

namespace DemoQA.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver _driver;
    protected abstract string Url { get; }
    
    public BasePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Open()
    {
        _driver.Navigate().GoToUrl(Url);
    }
}