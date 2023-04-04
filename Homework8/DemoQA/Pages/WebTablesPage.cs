using DemoQA.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQA.Pages;

public class WebTablesPage : BasePage
{
    public WebTablesPage(IWebDriver driver) : base(driver) { }

    protected override string Url => "https://demoqa.com/webtables";

    private IWebElement _addButton => _driver.FindElement(By.Id("addNewRecordButton"));
    private IWebElement _submitButton => _driver.FindElement(By.Id("submit"));

    private IWebElement _firstNameInput => _driver.FindElement(By.Id("firstName"));
    private IWebElement _lastNameInput => _driver.FindElement(By.Id("lastName"));
    private IWebElement _emailInput => _driver.FindElement(By.Id("userEmail"));
    private IWebElement _ageInput => _driver.FindElement(By.Id("age"));
    private IWebElement _salaryInput => _driver.FindElement(By.Id("salary"));
    private IWebElement _departmentInput => _driver.FindElement(By.Id("department"));

    private IWebElement _searchInput => _driver.FindElement(By.Id("searchBox"));
    private IWebElement _previousButton => _driver.FindElement(By.XPath("//div[contains(@class, '-previous')]"));
    private IWebElement _nextButton => _driver.FindElement(By.XPath("//div[contains(@class, '-next')]"));

    private IEnumerable<IWebElement> _rowsWithData =>
        _driver.FindElements(By.XPath("//div[contains(@class,'rt-td') and boolean(text())]/.."));

    private IEnumerable<IWebElement> _deleteButtons =>
        _driver.FindElements(By.XPath("//*[contains(@id, 'delete-record-')]"));

    private IEnumerable<IWebElement> _editButtons =>
        _driver.FindElements(By.XPath("//*[contains(@id, 'edit-record-')]"));

    public void AddNewRow()
    {
        _addButton.Click();
    }

    public void SubmitChanges()
    {
        _submitButton.Click();
    }

    public void FillInForm(Employee data)
    {
        _firstNameInput.SendKeys(data.FirstName);
        _lastNameInput.SendKeys(data.LastName);
        _emailInput.SendKeys(data.Email);
        _ageInput.SendKeys(data.Age);
        _salaryInput.SendKeys(data.Salary);
        _departmentInput.SendKeys(data.Department);
    }

    // Helper method for clearing input fields as Clear() method doesn't work for this case
    private void ClearField(IWebElement field)
    {
        new Actions(_driver)
            .Click(field)
            .KeyDown(Keys.Control)
            .SendKeys("a")
            .KeyUp(Keys.Control)
            .SendKeys(Keys.Delete)
            .Perform();
    }
    
    public void ClearForm()
    {
        ClearField(_firstNameInput);
        ClearField(_lastNameInput);
        ClearField(_emailInput);
        ClearField(_ageInput);
        ClearField(_salaryInput);
        ClearField(_departmentInput);
    }

    public void Search(string text)
    {
        _searchInput.SendKeys(text);
    }

    public void ClickNextButton()
    {
        new Actions(_driver)
            .ScrollToElement(_nextButton).Perform();
        
        _nextButton.Click();
    }

    public void ClickPreviousButton()
    {
        _previousButton.Click();
    }

    public IEnumerable<Employee> GetDataFromRows()
    {
        foreach (var data in _rowsWithData)
            yield return new Employee
            {
                FirstName = data.FindElement(By.XPath("./div[1]")).Text,
                LastName = data.FindElement(By.XPath("./div[2]")).Text,
                Age = data.FindElement(By.XPath("./div[3]")).Text,
                Email = data.FindElement(By.XPath("./div[4]")).Text,
                Salary = data.FindElement(By.XPath("./div[5]")).Text,
                Department = data.FindElement(By.XPath("./div[6]")).Text
            };
    }

    public void DeleteRowByIndex(int index)
    {
        var deleteButton = _deleteButtons.First(x => x.GetAttribute("id").EndsWith(index.ToString()));
        deleteButton.Click();
    }

    public void EditRowByIndex(int index)
    {
        var editButton = _editButtons.First(x => x.GetAttribute("id").EndsWith(index.ToString()));
        editButton.Click();
    }
}