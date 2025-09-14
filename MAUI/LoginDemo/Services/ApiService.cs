namespace LoginDemo.Services;

public interface IUserService
{
    bool ValidateCredentials(string username, string password);
}
public class UserService : IUserService
{
    public bool ValidateCredentials(string username, string password)
    {
        return username == "admin" && password == "password";
    }
}
