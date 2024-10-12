using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Collections;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController(IWebSocketManager webSocketManager) : ControllerBase
{
    [HttpPost]
    [Route("StartTask")]
    public ActionResult<Guid> StartTask()
    {
        var taskId = Guid.NewGuid();
        Task.Run(()=> LongRunningTask(taskId));
        return Ok(taskId);
    }

    private async Task LongRunningTask(Guid taskId)
    {
        for(int i = 0; i < 100; i++)
        {
            await Task.Delay(1000);
        }

        await webSocketManager.SendResponse(taskId, "Completed Task");
    }
}
