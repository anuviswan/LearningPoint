using Azure.Storage.Blobs;

namespace FileUploadEndPoint.Services;

public interface IBlobService
{
    Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadFile(IFormFile file, CancellationToken cancellationToken);
}

public class BlobService : IBlobService
{
    // TODO: Read from configuration file
    private const string ConnectionString = "";
    private const string ContainerName = "";

    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _blobContainerClient;

    public BlobService()
    {
        _blobServiceClient = new BlobServiceClient(ConnectionString);
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
    }
    public async Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadFile(IFormFile file, CancellationToken cancellationToken)
    {
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);

        var response = await _blobContainerClient.UploadBlobAsync(file.FileName, memoryStream, cancellationToken);

        return response;
    }
}
