using Microsoft.AspNetCore.Mvc;

namespace FileUploadEndPoint.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
