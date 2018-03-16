namespace App003.Ea.Wm.Contract
{
    public interface ILogin
    {
        bool Validate(string userName, string passWord);
    }
}
