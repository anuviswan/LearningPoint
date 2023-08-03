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

var inventoryList = new List<Inventory>()
{
    new Inventory(1,"Laptop"),
    new Inventory(2,"Laptop"),
    new Inventory(3,"Monitor"),
    new Inventory(4,"Monitor"),
    new Inventory(5,"Printer"),

};

var assignedInventoryList = new List<InventoryAssigned> 
{ 
    new InventoryAssigned(2, 101, new DateOnly(2023,1,1),new DateOnly(2023,6,1)),
    new InventoryAssigned(3, 101, new DateOnly(2023,1,1),new DateOnly(2023,10,1)),
    new InventoryAssigned(1, 102, new DateOnly(2022,1,1),new DateOnly(2023,5,1))
};

app.MapGet("/getinventorylist", () =>
{
    return inventoryList;
})
.WithName("GetInventoryList")
.WithOpenApi();

app.MapGet("/getassignedinventory", () =>
{
    return assignedInventoryList;
})
.WithName("GetAssignedInventory")
.WithOpenApi();

app.Run();


internal record Inventory(int Id, string InventoryName);
internal record InventoryAssigned(int InventoryId,int EmployeeId, DateOnly StartDate, DateOnly EndDate );
