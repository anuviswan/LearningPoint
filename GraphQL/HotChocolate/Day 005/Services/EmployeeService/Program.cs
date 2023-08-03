var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var employees = new List<Employee>
{
   new Employee(101,"John Doe",50,"India"),
   new Employee(102,"Jane Doe",45,"UK"),
   new Employee(103,"Jason doe",30,"USA"),
};

app.MapGet("/getallemployees", () =>
{
    return employees;
})
.WithName("GetAllEmployees")
.WithOpenApi();

app.MapPost("/addemployee", (Employee employee) =>
{
    employees.Add(employee);
}).WithName("AddEmployee")
.WithOpenApi();

app.Run();


internal record Employee(int Id,string Name, int Age, string Country);