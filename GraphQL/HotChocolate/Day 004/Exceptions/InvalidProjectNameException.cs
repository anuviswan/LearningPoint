public class InvalidProjectNameException : Exception
{
    public InvalidProjectNameException(string projectName) : base($"Invalid Project Name {projectName}")
    {
        
    }
}
