using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController(IWebSocketManager webSocketManager) : ControllerBase
{
    [HttpPost]
    [Route("StartTask")]
    public ActionResult StartTask()
    {
        Task.Run(()=> LongRunningTask());
        return Ok();
    }

    [HttpPost]
    [Route("Trigger")]
    public ActionResult TriggerTask()
    {
        Task.Run(() => AnotherLongRunningTask());
        return Ok();
    }

    private async Task LongRunningTask()
    {
        for(int i = 0; i < 100; i++)
        {
            await Task.Delay(1000);
        }

        await webSocketManager.SendResponse("Completed Task");
    }

    private async Task AnotherLongRunningTask()
    {
        for (int i = 0; i < 100; i++)
        {
            await Task.Delay(1000);
        }

        await webSocketManager.SendResponse("Completed Task");
    }
}
