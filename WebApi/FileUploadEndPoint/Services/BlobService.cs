using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace FileUploadEndPoint.Services;

public class BlobService : IBlobService
{
    // TODO: Read from configuration file
    private const string ConnectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://blobstorage:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";
    private const string ContainerName = "democontainer";

    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _blobContainerClient;

    public BlobService()
    {
        _blobServiceClient = new BlobServiceClient(ConnectionString);
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
    }
    public async Task<Azure.Response<BlobContentInfo>> UploadFile(IFormFile file,string blobFileName, CancellationToken cancellationToken = default)
    {
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);

        await _blobContainerClient.CreateIfNotExistsAsync().ConfigureAwait(false);
        var response = await _blobContainerClient.UploadBlobAsync(blobFileName, memoryStream, cancellationToken);
        return response;
    }


    public async Task<byte[]> GetFile(string blobFileName,CancellationToken cancellationToken = default)
    {
        var blobClient = _blobContainerClient.GetBlobClient(blobFileName);
        var response = await blobClient.DownloadContentAsync();
        return response.Value.Content.ToArray();
    }
}
