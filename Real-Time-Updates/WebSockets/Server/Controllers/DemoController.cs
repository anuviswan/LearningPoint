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
        Hangfire.BackgroundJob.Enqueue<DemoController>(x => x.LongRunningTask());
        //Task.Run(()=> LongRunningTask());
        return Accepted();
    }

    [HttpPost]
    [Route("Trigger")]
    public ActionResult TriggerTask()
    {
        Task.Run(() => AnotherLongRunningTask());
        return Ok();
    }


    [ApiExplorerSettings(IgnoreApi = true)]
    public  async Task LongRunningTask()
    {
        for(int i = 0; i < 100; i++)
        {
            await Task.Delay(1000);
        }

        await webSocketManager.SendResponse(new ApplicationMessageType(new ApplicationData("Job Completed","Information")));
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

public record MessageType<T>(T Data, string Type);

public record ApplicationData(string Message, string AlertType);
public record ApplicationMessageType(ApplicationData Data, string Type = "ApplicationType"):MessageType<ApplicationData>(Data,"ApplicationType");
