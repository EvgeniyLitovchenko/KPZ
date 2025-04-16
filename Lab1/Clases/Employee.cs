public class Employee : IEmployee
{
    public string Name { get; private set; }
    public string Role { get; private set; }

    public Employee(string name, string role)
    {
        Name = name;
        Role = role;
    }
}