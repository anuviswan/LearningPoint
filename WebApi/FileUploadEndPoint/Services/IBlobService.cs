using Azure.Storage.Blobs;

namespace FileUploadEndPoint.Services;

public interface IBlobService
{
    Task UploadFile(IFormFile file);
}

public class BlobService : IBlobService
{
    // TODO: Read from configuration file
    private const string ConnectionString = "";
    private const string ContainerName = "";

    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _bloblContainerClient;

    public BlobService()
    {
        _blobServiceClient = new BlobServiceClient(ConnectionString);
        _bloblContainerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
    }
    public Task UploadFile(IFormFile file)
    {
        throw new NotImplementedException();
    }
}
