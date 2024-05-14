using Azure.Storage.Blobs.Models;

namespace FileUploadEndPoint.Services;

public interface IBlobService
{
    Task<Azure.Response<BlobContentInfo>> UploadFile(IFormFile file, string blobFileName, CancellationToken cancellationToken = default);
}
