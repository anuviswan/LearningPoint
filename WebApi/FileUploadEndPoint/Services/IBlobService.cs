namespace FileUploadEndPoint.Services;

public interface IBlobService
{
    Task UploadFile(IFormFile file);
}

public class BlobService : IBlobService
{
    public Task UploadFile(IFormFile file)
    {
        throw new NotImplementedException();
    }
}
