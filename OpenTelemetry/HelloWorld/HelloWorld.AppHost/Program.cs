var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HelloWorld>("helloworld");

builder.Build().Run();
