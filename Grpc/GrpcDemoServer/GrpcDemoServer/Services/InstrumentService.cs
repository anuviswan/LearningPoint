using Grpc.Core;

namespace GrpcDemoServer.Services;

public class InstrumentService: Instrument.InstrumentBase
{
    public override Task<ReadStatusResponse> ReadStatus(ReadStatusRequest request, ServerCallContext context)
    {
        return Task.FromResult(new ReadStatusResponse
        {
            Status = $"Connected : {TimeOnly.FromDateTime(DateTime.Now).ToLongTimeString()}"
        }) ;
    }

    public override async Task Subscribe(RawDataRequest request, IServerStreamWriter<RawDataResponse> responseStream, ServerCallContext context)
    {
        for(int i = 0; i < request.MaxItems; i++)
        {
            await Task.Delay(1000);
            await responseStream.WriteAsync(new RawDataResponse
            {
                Id = i,
                Description = $"Description {i}"
            });
        }
    }
}
