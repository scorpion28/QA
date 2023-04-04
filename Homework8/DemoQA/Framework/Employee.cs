namespace DemoQA.Framework;

public record Employee
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Age { get; init; }
    public string Salary { get; init; }
    public string Department { get; init; }
}