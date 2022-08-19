using Grpc.Core;

namespace GrpcDemoServer.Services;

public class InstrumentService: Instrument.InstrumentBase
{
    public override Task<ReadStatusResponse> ReadStatus(ReadStatusRequest request, ServerCallContext context)
    {
        return Task.FromResult(new ReadStatusResponse
        {
            Status = $"Connected : {TimeOnly.FromDateTime(DateTime.Now)}"
        }) ;
    }
}
