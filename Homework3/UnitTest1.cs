using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Homework3;

public class Tests
{
    IWebDriver Driver { get; set; }

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        // Submit button isn't visible on 100% scale
        options.AddArgument("--force-device-scale-factor=0.9");
        Driver = new ChromeDriver(options);
    }

    [Test]
    public void FillForm()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/");

        var formsCard = Driver.FindElement(By.XPath("//div[contains(@class, 'category-cards')]/div[2]"));
        formsCard.Click();

        var practiceFormButton = Driver.FindElement(By.XPath("//span[contains(text(), \"Practice Form\")]/.."));
        practiceFormButton.Click();

        FillName();
        FillEmail();
        FillGender();
        FillPhoneNumber();
        FillBirthDate();
        FillSubjects();
        FillHobbies();
        FillPicture();
        FillCurrentAddress();
        FillStateAndCity();
        
        var submitButton = Driver.FindElement(By.Id("submit"));
        submitButton.Click();
    }

    private void FillName()
    {
        var firstNameInput = Driver.FindElement(By.Id("firstName"));
        firstNameInput.SendKeys("Oleksandr");

        var lastNameInput = Driver.FindElement(By.Id("lastName"));
        lastNameInput.SendKeys("Demianiv");
    }

    private void FillEmail()
    {
        var emailInput = Driver.FindElement(By.Id("userEmail"));
        emailInput.SendKeys("z92k1t@gmail.com");
    }

    private void FillGender()
    {
        var maleGenderCheckbox = Driver.FindElement(By.XPath("//input[@id='gender-radio-1']/.."));
        maleGenderCheckbox.Click();
    }

    private void FillPhoneNumber()
    {
        var phoneInput = Driver.FindElement(By.Id("userNumber"));
        phoneInput.SendKeys("0987654321");
    }

    private void FillBirthDate()
    {
        var dateOfBirth = Driver.FindElement(By.Id("dateOfBirthInput"));
        dateOfBirth.Click();

        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        var monthSelect = wait.Until(ExpectedConditions.ElementIsVisible(
            By.XPath("//select[contains(@class, 'react-datepicker__month-select')]")));
        new SelectElement(monthSelect).SelectByText("January");

        var yearSelect =
            new SelectElement(
                Driver.FindElement(By.XPath("//select[contains(@class, 'react-datepicker__year-select')]")));
        yearSelect.SelectByText("2000");
        
        var firstDayOfMonth = Driver.FindElement(By.XPath("//div[contains(@class, 'react-datepicker__day--001')]"));
        firstDayOfMonth.Click();
    }

    private void FillSubjects()
    {
        var subjects = Driver.FindElement(By.Id("subjectsInput"));
        
        subjects.SendKeys("Maths");
        subjects.SendKeys(Keys.Enter);
        
        subjects.SendKeys("English");
        subjects.SendKeys(Keys.Enter);
        
        subjects.SendKeys("Arts");
        subjects.SendKeys(Keys.Enter);
    }

    private void FillHobbies()
    {
        var readingCheckbox =
            Driver.FindElement(By.XPath("//div[@id='hobbiesWrapper']//label[@for='hobbies-checkbox-2']"));
        readingCheckbox.Click();
        
        var musicCheckbox = Driver.FindElement(By.XPath("//div[@id='hobbiesWrapper']//label[@for='hobbies-checkbox-3']"));
        musicCheckbox.Click();
    }

    private void FillPicture()
    {
        var choosePictureButton = Driver.FindElement(By.Id("uploadPicture"));
        var pictureToSend = new FileInfo("res/qaa.png").FullName;
        choosePictureButton.SendKeys(pictureToSend);
    }

    private void FillCurrentAddress()
    {
        var currentAddress = Driver.FindElement(By.Id("currentAddress"));
        currentAddress.SendKeys("Wall Street, 5");
    }

    private void FillStateAndCity()
    {
        var state = Driver.FindElement(By.Id("react-select-3-input"));
        state.SendKeys("Rajasthan");
        state.SendKeys(Keys.Enter);

        var city = Driver.FindElement(By.Id("react-select-4-input"));
        city.SendKeys("Jaipur");
        city.SendKeys(Keys.Enter);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}