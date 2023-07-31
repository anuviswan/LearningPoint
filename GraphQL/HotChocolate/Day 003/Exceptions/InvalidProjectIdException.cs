public class InvalidProjectIdException :Exception
{
    public InvalidProjectIdException(int id):base($"Invalid ProjectId {id}")
    {
    }
}
