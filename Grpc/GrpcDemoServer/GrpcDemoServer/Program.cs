using GrpcDemoServer.Services;
using Grpc.AspNetCore.Web;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

// Use CORS to access different domain
builder.Services.AddCors(opt => opt.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

var app = builder.Build();

app.UseGrpcWeb();
// To enable it as default
// app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled =  true});


app.MapGrpcService<GreeterService>()
    .EnableGrpcWeb();
app.MapGrpcService<InstrumentService>()
    .EnableGrpcWeb(); ;
app.MapGrpcReflectionService();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
