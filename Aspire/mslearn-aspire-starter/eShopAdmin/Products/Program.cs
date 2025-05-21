using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDbContext<ProductDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ProductsContext") ?? throw new InvalidOperationException("Connection string 'ProductsContext' not found.")));

// Add services to the container.
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.MapProductEndpoints();

app.UseStaticFiles();

app.CreateDbIfNotExists();

app.Run();
