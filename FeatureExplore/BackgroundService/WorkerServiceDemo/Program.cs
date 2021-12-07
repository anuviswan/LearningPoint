using WorkerServiceDemo;

IHost host = Host.CreateDefaultBuilder(args)
    // Uncommment following line to make it a Windows Service
    //.UseWindowsService() 
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
