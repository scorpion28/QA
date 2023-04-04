using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQA.Pages;

public class ButtonsPage : BasePage
{
    public ButtonsPage(IWebDriver driver) : base(driver) { }

    protected override string Url => "https://demoqa.com/buttons";
    
    private IWebElement _doubleClickButton => _driver.FindElement(By.Id("doubleClickBtn"));
    private IWebElement _rightClickButton => _driver.FindElement(By.Id("rightClickBtn"));
    private IWebElement _dynamicClickButton => _driver.FindElement(By.XPath("//button[text()='Click Me']"));
    private IWebElement _doubleClickMessage => _driver.FindElement(By.Id("doubleClickMessage"));
    private IWebElement _rightClickMessage => _driver.FindElement(By.Id("rightClickMessage"));
    private IWebElement _clickMessage => _driver.FindElement(By.Id("dynamicClickMessage"));

    public void UseDoubleClickButton()
    {
        var actions = new Actions(_driver);
        actions.DoubleClick(_doubleClickButton);
        actions.Perform();
    }

    public void UseRightClickButton()
    {
        var actions = new Actions(_driver);
        actions.ContextClick(_rightClickButton);
        actions.Perform();
    }

    public void UseDynamicClickButton()
    {
        _dynamicClickButton.Click();
    }

    public string GetDoubleClickMessage()
    {
        return _doubleClickMessage.Text;
    }

    public string GetRightClickMessage()
    {
        return _rightClickMessage.Text;
    }

    public string GetDynamicClickMessage()
    {
        return _clickMessage.Text;
    }
}