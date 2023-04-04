using DemoQA.Framework;

namespace DemoQA.Tests;

public class TablesTest : BaseTest
{
    [Test]
    public void AddButton_AddsNewRowToTable()
    {
        var inputData = new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Age = "30",
            Salary = "10000",
            Department = "IT"
        };

        Pages.WebTables.Open();
        Pages.WebTables.AddNewRow();
        Pages.WebTables.FillInForm(inputData);
        Pages.WebTables.SubmitChanges();

        var newRow = Pages.WebTables.GetDataFromRows().First(x => x == inputData);

        Assert.NotNull(newRow);
    }

    [Test]
    public void Search_ShowsCorrectRows()
    {
        var expectedRowCount = 1;
        var expectedName = "Kierra";

        Pages.WebTables.Open();
        Pages.WebTables.Search(expectedName);

        var actualRowCount = Pages.WebTables.GetDataFromRows().Count();
        var actualName = Pages.WebTables.GetDataFromRows().First().FirstName;

        Assert.AreEqual(expectedRowCount, actualRowCount);
        Assert.AreEqual(expectedName, actualName);
    }

    [Test]
    public void OnDeleteButtonPress_RowDeletesFromTable_()
    {
        var expectedCount = 0;

        Pages.WebTables.Open();
        Pages.WebTables.DeleteRowByIndex(1);
        Pages.WebTables.DeleteRowByIndex(2);
        Pages.WebTables.DeleteRowByIndex(3);

        var actualCount = Pages.WebTables.GetDataFromRows().Count();

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void OnEditButtonPressAndSubmittingChanges_RowDataChanges()
    {
        Pages.WebTables.Open();
        Pages.WebTables.EditRowByIndex(1);

        var dataFromFirstRow = Pages.WebTables.GetDataFromRows().First();

        var modifiedData = dataFromFirstRow with
        {
            FirstName = "Sofie",
            Salary = "50000"
        };

        Pages.WebTables.ClearForm();
        Pages.WebTables.FillInForm(modifiedData);
        Pages.WebTables.SubmitChanges();
        
        var actualData = Pages.WebTables.GetDataFromRows().First();
        
        Assert.AreEqual(modifiedData, actualData);
    }
    
    [Test]
    public void NavigationAndPaginationTest()
    {
        Pages.WebTables.Open();
        
        var inputData = new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Age = "30",
            Salary = "10000",
            Department = "IT"
        };

        // Adding 12 rows(to the 3 already existing) to the table
        for (int i = 0; i < 12; i++)
        {
            Pages.WebTables.AddNewRow();
            Pages.WebTables.FillInForm(inputData);
            Pages.WebTables.SubmitChanges();
        }
        
        Pages.WebTables.ClickNextButton();
        var expectedRowsCountOnSecondPage = 5;
        var actualRowsCount = Pages.WebTables.GetDataFromRows().Count();
        
        Assert.AreEqual(expectedRowsCountOnSecondPage, actualRowsCount);
        Pages.WebTables.ClickPreviousButton();
    }
    
    // Intentionally failing test for which screenshot will be generated
    [Test]
    public void AlwaysFails()
    {
        Pages.WebTables.Open();
        Assert.Fail();
    }
}