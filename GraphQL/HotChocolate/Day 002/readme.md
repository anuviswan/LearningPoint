[Earlier in this series](https://bytelanguage.com/2023/07/26/graphql-day-001-creating-your-first-graphql-server-with-hotchocolate/), we will created our first GraphQL Server. If you had noticed we defined our data types as plain C# classes. This was a simple example of Annotation based approach, though actually we did not use any annotation. However, things can change when one needs to expose another query resolver. 

### Annotation Based Type Definition
In the [previous example](https://bytelanguage.com/2023/07/26/graphql-day-001-creating-your-first-graphql-server-with-hotchocolate/), we had only one query resolver - `ProjectQueryResolver`. Let us now extend the project and add a `TimeLog` type and a query resolver for the same. It is better to have a QueryResolver for each type to isolate the code.

Let us first define our type `TimeLog`.
```csharp
public class TimeLog
{
    public int Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string User { get; set; }
}
```

and add some `TimeLog` information as seeds in our `DbContext`.

```csharp
modelBuilder.Entity<TimeLog>().HasData(new TimeLog
{
    Id = 1,
    From = new DateTime(2020, 7, 24, 12, 0, 0),
    To = new DateTime(2020, 7, 24, 14, 0, 0),
    User = "Giorgi"
}, new TimeLog
{
    Id = 2,
    From = new DateTime(2020, 7, 24, 16, 0, 0),
    To = new DateTime(2020, 7, 24, 18, 0, 0),
    User = "Giorgi"
}, new TimeLog
{
    Id = 3,
    From = new DateTime(2020, 7, 24, 20, 0, 0),
    To = new DateTime(2020, 7, 24, 22, 0, 0),
    User = "Giorgi"
});
```

The next step is to add our Query Resolver for the `TimeLog`. 

```csharp
public class TimeLogQueryResolver
{
    public IEnumerable<TimeLog> FetchAllTimeLog([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext)
    {
        return dbContext.TimeLogs;
    }
}
```

Nothing fancy yet.In the Annotation-based approach all public properties and methods are implicitly mapped to fields on the schema object type.

 We might be tempted to register the `TimeLogQueryResolver` just like did for `ProjectQueryResolver` in our [previous example](https://bytelanguage.com/2023/07/26/graphql-day-001-creating-your-first-graphql-server-with-hotchocolate/).

```csharp
builder.Services.AddGraphQLServer()
                .AddQueryType<ProjectQueryResolver>()
                .AddQueryType<TimeLogQueryResolver>();
var app = builder.Build();
app.MapGraphQL();
```

While this doesn't throw an error, you would notice when you check the _Schema Definition_ in _Banana Cake Pop_ IDE that the `TimeLog` queries are not part of the schema. 

This is where we introduce _Type Extensions_. Type Extensions in HotChocolate is add,remove or replace fields on existing types, even if we do not have access to them. For example, your types could be defined in an external library. In such a scenario, you would not be able to access the class and add the necessary fields/methods/annotations.

This is where _Type Extensions_ comes into rescue. For example, if we have a type `Person` defined in an external third party library, which we consume, and we need to add another field to the type, we could do the following.

```c#

// Original Type
public class Person
{
    public string Name {get;set;}
}

// Extending in our application
[ExtendObjectType(typeof(Person))]
public class PersonExtension
{
    public int Age {get;set;}
}
```

Back to our scenario to use multiple resolvers, we could make use of `ExtendObjectType` to extend our `Query` types. For example,

```csharp
public class Query
{
}

// Project Query Resolver
[ExtendObjectType(typeof(Query))]
public class ProjectQueryResolver
{
    // Omitted code for brevity
}

// TimeLog Query Resolver
[ExtendObjectType(typeof(Query))]
public class TimeLogQueryResolver
{
    // Omitted code for brevity
}
```

For ensuring both (multiple) query resolvers are supported, we need to add a Query Type (say _Query_) and add  resolvers to support the multiple schema of type  _Query_. For this, we would need to use our first Annotation `ExtendObjectType`.  For example, we can modify the above code as 

```csharp
builder.Services.AddGraphQLServer()
                .AddQueryType<Query>();

```

Annotations also allows us to add description to our schema, using the `GraphQLDescriptionAttribute`.

For example,
```csharp
[GraphQLDescription("Describes a Project information")]
public class Project
{
    [GraphQLDescription("Unique Identifier of the Project")]
    public int Id { get; set; }

    [GraphQLDescription("Name of the Project")]
    public string Name { get; set; }

    [GraphQLDescription("Describes who created the project")]
    public string CreatedBy { get; set; }
}

[ExtendObjectType(typeof(Query))]
public class ProjectQueryResolver
{
    [GraphQLDescription("Fetch all projects")]
    public IEnumerable<Project> FetchAllProjects([Service(ServiceKind.Synchronized)]DemoGraphContext dbContext)
    {
        return dbContext.Projects;
    }

    [GraphQLDescription("Fetch project by name")]
    public Project? FetchProjectByName([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,string projectName)
    {
        return dbContext.Projects.FirstOrDefault(x => string.Equals(x.Name, projectName, StringComparison.OrdinalIgnoreCase));
    }
    
}
```

You could use the  _Banana Cake Pop_ IDE Schema Reference tab to see the descriptions you have just added.


### Code First Approach

While the _Annotation Based Approach_ works perfectly with no functional limitations, it does have a drawback. With the approach, you are forced to add `HotChocolate` attributes to your regular data classes. While this does makes life easy, not everyone is a fan of cluttering the DTO classes with attributes which doesn't quite belong there.

This is where _Code First Approach_ come into play. The _Code First Approach_ allows you to separate the DTO classes and corresponding GraphQL behavior with the help of `ObjectType<T>`. We create a new class for each type we want to expose, inheriting from `Object<T>` to map our type. For example,

```csharp
public class ProjectType:ObjectType<Project>
{
    protected override void Configure(IObjectTypeDescriptor<Project> descriptor)
    {
        descriptor.Description("Describes a Project information");

        descriptor.Field(x => x.Id)
                  .Description("Unique Identifier of the Project");

        descriptor.Field(x => x.Name)
                  .Description("Name of the Project");

        descriptor.Field(x => x.CreatedBy)
          .Description("Describes who created the project");
    }
}
```

As seen in the above example, we have derived from `Object<T>` to define our new Type `ProjectType`. This new type would help in defining and describing our GraphQL typed mapped to DTO `Project`. We have _overridden_ the `Configure` method to add our custom description.

We could use the `IObjectTypeDescriptor<T>` to ignore fields from the original field if needed. For example,

```csharp
descriptor.Field(x => x.Name).Ignore();
```

As mentioned earlier, in _Annotation Based_ approach, all public properties and methods are implicitly mapped to the schema object type. It is same for _Code First_ approach. However, with _Code First_ approach, you can choose to enable explicit binding, allowing us to choose what to include, rather than _ignoring_ fields like in the example above.

```csharp
services.AddGraphQLServer()
        .ModifyOptions(options =>
        {
            options.DefaultBindingBehavior = BindingBehavior.Explicit;
        });
```


In this part of series, we have explored two different approaches for defining types. There is of course the third approach of 'Scheme First' approach. But I will leave it out of the series. Anyone interested could look it up in the official documentation.

Happy Weekend and in the next part, we will look into mutations.