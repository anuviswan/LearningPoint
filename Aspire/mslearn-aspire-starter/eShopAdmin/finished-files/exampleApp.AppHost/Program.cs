var builder = DistributedApplication.CreateBuilder(args);

var products = builder.AddProject<Projects.Products>("products");

builder.AddProject<Projects.Store>("store")
  .WithReference(products);

builder.Build().Run();
