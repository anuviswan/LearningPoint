// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo code for 'required' modifier");

var user = new User() { Name = "John Doe" };



public class User
{
    public required string  Name{ get; init; }
}
