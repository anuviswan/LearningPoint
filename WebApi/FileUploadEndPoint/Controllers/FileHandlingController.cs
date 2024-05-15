using Azure;
using FileUploadEndPoint.Dtos;
using FileUploadEndPoint.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadEndPoint.Controllers;

[ApiController]
[Route("api/file")]
public class FileHandlingController : ControllerBase
{
    private readonly IBlobService _blobService;
    public FileHandlingController(IBlobService blobService)
    {
        _blobService = blobService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("uploadfile")]
    public async Task<IActionResult> UploadFile([FromForm]FileInput file)
    {
        try
        {
            var response = await _blobService.UploadFile(file.File, file.Key, default).ConfigureAwait(false);
        }
        catch (RequestFailedException e)
        {
            return BadRequest($"File upload failed :{e.Message}");
        }
        
        return Ok("File uploaded successfully");
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("get")]
    public async Task<ActionResult> Get(string fileName)
    {
        var response = await _blobService.GetFile(fileName).ConfigureAwait(false);
        return File(response, "application/jpg",fileName);
    }
}
