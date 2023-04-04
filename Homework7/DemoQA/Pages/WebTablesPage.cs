using OpenQA.Selenium;

namespace DemoQA.Pages;

public class WebTablesPage
{
    private readonly IWebDriver _driver;

    public WebTablesPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement _addButton => _driver.FindElement(By.Id("addNewRecordButton"));
    private IWebElement _submitButton => _driver.FindElement(By.Id("submit"));

    private IWebElement _firstNameInput => _driver.FindElement(By.Id("firstName"));
    private IWebElement _lastNameInput => _driver.FindElement(By.Id("lastName"));
    private IWebElement _emailInput => _driver.FindElement(By.Id("userEmail"));
    private IWebElement _ageInput => _driver.FindElement(By.Id("age"));
    private IWebElement _salaryInput => _driver.FindElement(By.Id("salary"));
    private IWebElement _departmentInput => _driver.FindElement(By.Id("department"));

    private IWebElement _searchInput => _driver.FindElement(By.Id("searchBox"));
    private IWebElement _previousButton => _driver.FindElement(By.XPath("//div[contains(@class, '-previous')]/button"));
    private IWebElement _nextButton => _driver.FindElement(By.XPath("//div[contains(@class, '-next')]/button"));

    private IEnumerable<IWebElement> _rowsWithData =>
        _driver.FindElements(By.XPath("//div[contains(@class,'rt-td') and boolean(text())]/.."));

    private IEnumerable<IWebElement> _deleteButtons =>
        _driver.FindElements(By.XPath("//*[contains(@id, 'delete-record-')]"));

    private IEnumerable<IWebElement> _editButtons => _driver.FindElements(By.Id("edit-record-"));

    public void AddNewRow()
    {
        _addButton.Click();
    }

    public void SubmitNewRow()
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

    public void Search(string text)
    {
        _searchInput.SendKeys(text);
    }

    public void ClickNextButton()
    {
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

    public void OpenEditFormByRowIndex(int index)
    {
        var editButton = _editButtons.First(x => x.GetAttribute("id").EndsWith(index.ToString()));
        editButton.Click();
    }
}

public record Employee
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Age { get; init; }
    public string Salary { get; init; }
    public string Department { get; init; }
}