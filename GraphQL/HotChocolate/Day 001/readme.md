# Creating your first GraphQL Server

In the earlier part of the series, we familiarized ourselves with the different building blocks of GraphQL. We also understood the need of GraphQL and how it fares compared to REST endpoints. 

In this post, we will create our first GraphQL server. For sake of this example, we will be using the [`HotChocolate`](https://chillicream.com/docs/hotchocolate/v13) library for building our GraphQL server.

Before we begin implementing `HotChocolate`, let us define our Web API. We will keep the implementation as simple as possible, using in-memory databases and Entity Framework.

```csharp
builder.Services.AddDbContext<TimeGraphContext>(context =>
{
    context.UseInMemoryDatabase("TimeGraphServer");
});
```

`TimeGraphContext` is defined as 

```csharp
public class DemoGraphContext : DbContext
{
    public DemoGraphContext(DbContextOptions<DemoGraphContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Project> Projects { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(new Project
        {
            CreatedBy = "Giorgi",
            Id = 1,
            Name = "Migrate to TLS 1.2"
        }, new Project
        {
            CreatedBy = "Giorgi",
            Id = 2,
            Name = "Move Blog to Hugo"
        });
    }
}

```

I will leave out further details of the Web API, and would rather prefer to focus on implementing our GraphQL Server. So let us get started.

### Installing HotChocolate

As mentioned earlier, we will be using the `HotChocolate` library for our implementation. Let us go ahead and install the required packages.
```
dotnet add package HotChocolate.AspNetCore
```

### Define the Types.

The first step involve defining the required types. 

```csharp
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
}

```

We also have to define the Query as part of Types.

```csharp
public class ProjectQueryResolver
{
    public IEnumerable<Project> FetchAllProjects([Service(ServiceKind.Synchronized)]DemoGraphContext dbContext)
    {
        return dbContext.Projects;
    }

    public Project? FetchProjectByName([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,string projectName)
    {
        return dbContext.Projects.FirstOrDefault(x => string.Equals(x.Name, projectName, StringComparison.OrdinalIgnoreCase));
    }
    
}
```

### Register GraphQL Service

The next step is to register our GraphQL service in the pipeline. This can be done as follows

```csharp
builder.Services.AddGraphQLServer()
                .AddQueryType<ProjectQueryResolver>();
var app = builder.Build();
app.MapGraphQL();
```

That would be all we need run our first GraphQL server. Let us run the application and see the server in action.

### Testing

Go to `https://locahost:port:/graphql/` to access the server. Hot-chocolate GraphQL provides a graphical IDE, Banana Cake Pop - a tool for developers to design and debug GraphQL queries and mutations.

<<image>>

It provides developers the entire schema definition, in addition to the IDE for specifying the query to send. Let us try our first query.

```text
query{
  fetchAllProjects{
    name,
    createdBy
  }
}
```

Based on our hard-coded in-memory database, we get the following result.

```text
{
  "data": {
    "fetchAllProjects": [
      {
        "name": "Migrate to TLS 1.2",
        "createdBy": "Giorgi"
      },
      {
        "name": "Move Blog to Hugo",
        "createdBy": "Giorgi"
      }
    ]
  }
}
```

Let us try another query. This time with a parameter.

```
query($name:String!){
  fetchProjectByName(projectName: $name ){
    name,
    createdBy
  }
}
```

Look how we have passed an arguement to the query. The value of the parameter has to be given separately.

```
{
  "name" : "Move Blog to Hugo"
}
```

This would provide the result as follows.

```
{
  "data": {
    "fetchProjectByName": {
      "name": "Move Blog to Hugo",
      "createdBy": "Giorgi"
    }
  }
}
```

All good so far, we have managed to run our first GraphQL server using `HotChocolate`. In this part of article, we will add multiple query resolvers and explore different ways to define types - namely, _Schema-First, Annotation-based, and Code First_. 