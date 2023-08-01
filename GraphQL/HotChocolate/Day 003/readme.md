# Defining Mutations

Until now, we dealt with, what we could call a readonly system. In other words, we defined queries which does not alter the system. But what if we intent to alter the system, for example, we want to add a new record. This is where `mutation` comes into the play.

The mutation type in GraphQL is used to alter data. Let us go ahead and create our first mutation.

```csharp
public class ProjectMutation
{
    public async Task<Project> AddProjectType([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext, Project project)
    {
        var result = await dbContext.AddAsync(project);
        await dbContext.SaveChangesAsync();
        return result.Entity;
    }
}
```

We can now register our mutation, just like we did our queries. 

```
builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddTypeExtension<ProjectQueryResolver>()
                .AddTypeExtension<TimeLogQueryResolver>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<ProjectMutation>();
```

Let us now fire our _Banana Pop_ IDE and test our mutation.

```text
mutation{
  addProjectType(project: {
    name : "Sample Project",
    id : 45,
    createdBy: "John Doe"
  }){
    name
  }
}
```

The above would add a new record to our database. Since there is possibility to execute multiple mutations, HotChocolate supports transactions in mutations. We can enable transactions using the `AddDefaultTransactionScopeHandler()` extension method.

```csharp
builder.Services.AddGraphQLServer()
                .AddDefaultTransactionScopeHandler()
                .AddQueryType<Query>()
                .AddTypeExtension<ProjectQueryResolver>()
                .AddTypeExtension<TimeLogQueryResolver>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<ProjectMutation>();
```


### Conventions

In GraphQL, the recommended best practise for creating mutation involves having a single arguement called input, with each mutation returning a payload. This might introduce a lot of boiler-plate code and HotChocolate has build functionalities to reduce this boiler-plate code.

You can enable mutation conventions by using the `.AddMutationConventions()` method.

```csharp
builder.Services.AddGraphQLServer()
                .AddDefaultTransactionScopeHandler()
                .AddMutationConventions()
                .AddQueryType<Query>()
                .AddTypeExtension<ProjectQueryResolver>()
                .AddTypeExtension<TimeLogQueryResolver>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<ProjectMutation>();
```


This is especially useful when you want to pass multiple parameters and want to avoid create a _composite type_ just to follow the convention of single `input` type.
With the conventions enabled, you can alter your mutation as follows.

```csharp
[UseMutationConvention]
[GraphQLDescription("Add Project")]
public async Task<Project> AddProject([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,
    [ID]int id, string name, string createdBy)
{
    var result = await dbContext.AddAsync(new Project
    {
        Id = id,
        Name = name,
        CreatedBy = createdBy
    });

    await dbContext.SaveChangesAsync();
    return result.Entity;
}
```


The `AddMutationConventions()` method ensures conventions are by default used by all mutations. You could make it _opt in_ by pass a `false` value to the  `applyToAllMutations` parameter. For example,

```
builder.Services.AddGraphQLServer()
                .AddDefaultTransactionScopeHandler()
                .AddMutationConventions(applyToAllMutations:false)
                .AddQueryType<Query>()
                .AddTypeExtension<ProjectQueryResolver>()
                .AddTypeExtension<TimeLogQueryResolver>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<ProjectMutation>();
```

In such cases, you can _opt in_  each mutation you want to use convention with the `[UseMutationConvention]` attribute.

### Handling Errors

HotChocolate allows to handle errors methodologically with minimum fuss by using the signal states. The field (could be query as well), in current context mutations, to define what are domain errors, which would be defined as part of schema. Rest of the exceptions would be treated as runtime errors.

For example, let us define two custom exceptions for our `AddProject` mutation.

```csharp
public class InvalidProjectIdException :Exception
{
    public InvalidProjectIdException(int id):base($"Invalid ProjectId {id}")
    {
    }
}

public class InvalidProjectNameException : Exception
{
    public InvalidProjectNameException(string projectName) : base($"Invalid Project Name {projectName}")
    {
        
    }
}
```

We can now ensure that our `AddMutation` field accepts the defined exceptions as part of its schema using the `ErrorAttribute`.

```csharp
[UseMutationConvention]
[GraphQLDescription("Add Project")]
[Error(typeof(InvalidProjectIdException))]
[Error(typeof(InvalidProjectNameException))]
public async Task<Project> AddProject([Service(ServiceKind.Synchronized)] DemoGraphContext dbContext,
    [ID]int id, string name, string createdBy)
{
  // Code omitted for brevity
}
```
The above code would define a _GraphQL Schema_ as following.

```
type Mutation {
  """
  Add Project
  """
  addProject(input: AddProjectInput!): AddProjectPayload!
  addProjectType(project: ProjectInput!): Project!
}

type InvalidProjectIdError implements Error {
  message: String!
}

type InvalidProjectNameError implements Error {
  message: String!
}

interface Error {
  message: String!
}


input AddProjectInput {
  id: ID!
  name: String!
  createdBy: String!
}

union AddProjectError = InvalidProjectIdError | InvalidProjectNameError

type AddProjectPayload {
  project: Project
  errors: [AddProjectError!]
}

```

As you can notice, the `AddProjectPayload` now has two properties, _project_ and _errors_, each indicating valid state and state when an error occurs. The `errors` could be either of type `InvalidProjectIdError` or `InvalidProjectNameError`.

We can now call the mutation with errors defined as expected field (on error).

```
mutation{
  addProject(input: {
    name: "Demo Project",
    id: -1,
    createdBy : "John Doe"
  }){
    project{
      id,
      name,
    },
    errors{
      ...InvalidProjectName
      ...InvalidProjectId
    }
  }
}

fragment InvalidProjectName on InvalidProjectNameError{
  message
}

fragment InvalidProjectId on InvalidProjectIdError{
  message
}
```

Notice we have used _fragments_ to define the particular type of exceptions.The above query would raise an exception (`InvalidProjectIdException`). The output would be as follows.

```
{
  "data": {
    "addProject": {
      "project": null,
      "errors": [
        {
          "message": "Invalid ProjectId -1"
        }
      ]
    }
  }
}
```

So far we have looked into queries and mutations. The third remaining key component is `subscriptions`, which we will address in the next part. Until then, if you are interested in the source code discussed in this tutorial, you can check my [Github](https://github.com/anuviswan/LearningPoint/tree/master/GraphQL/HotChocolate/Day%20003)
