using DemoQA.Pages;
using OpenQA.Selenium;

namespace DemoQA.Framework;

public class PageList
{
    private readonly IWebDriver _driver;
    
    private ButtonsPage _buttonsPage;
    private WebTablesPage _webTablesPage;

    public PageList(IWebDriver driver)
    {
        _driver = driver;
    }

    public ButtonsPage Buttons => _buttonsPage ??= new ButtonsPage(_driver);
    public WebTablesPage WebTables => _webTablesPage ??= new WebTablesPage(_driver);
}