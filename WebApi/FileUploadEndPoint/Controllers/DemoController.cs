using FileUploadEndPoint.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadEndPoint.Controllers;

public class DemoController : Controller
{
    private readonly IBlobService _blobService;
    public DemoController(IBlobService blobService)
    {
        _blobService = blobService;
    }
    public async Task UploadFile(IFormFile file)
    {
        await _blobService.UploadFile(file,null).ConfigureAwait(false);   
    }
}
