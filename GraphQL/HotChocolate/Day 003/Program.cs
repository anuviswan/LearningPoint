using GraphQLDemo.Database;
using GraphQLDemo.GraphQl.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DemoGraphContext>(context =>
{
    context.UseInMemoryDatabase("TimeGraphServer");
});

builder.Services.AddGraphQLServer()
                .AddDefaultTransactionScopeHandler()
                .AddMutationConventions()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

var app = builder.Build();
app.MapGraphQL();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
