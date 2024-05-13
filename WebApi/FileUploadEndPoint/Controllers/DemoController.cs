using Microsoft.AspNetCore.Mvc;

namespace FileUploadEndPoint.Controllers;

public class DemoController : Controller
{
    public async Task UploadFile(IFormFile file)
    {
        // TODO : Read file and upload to blob
    }
}
