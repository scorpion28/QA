namespace DemoQA.Tests;

public class ButtonsTest : BaseTest
{
    [Test]
    public void DoubleClickButton_CreatesCorrectMessage()
    {
        Pages.Buttons.Open();
        Pages.Buttons.UseDoubleClickButton();

        var expectedMessage = "You have done a double click";
        var actualMessage = Pages.Buttons.GetDoubleClickMessage();

        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void RightClickButton_CreatesCorrectMessage()
    {
        Pages.Buttons.Open();
        Pages.Buttons.UseRightClickButton();

        var expectedMessage = "You have done a right click";
        var actualMessage = Pages.Buttons.GetRightClickMessage();

        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void DynamicClickButton_CreatesCorrectMessage()
    {
        Pages.Buttons.Open();
        Pages.Buttons.UseDynamicClickButton();

        var expectedMessage = "You have done a dynamic click";
        var actualMessage = Pages.Buttons.GetDynamicClickMessage();

        Assert.AreEqual(expectedMessage, actualMessage);
    }
}