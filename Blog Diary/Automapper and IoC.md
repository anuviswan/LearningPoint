In this article we will examine how to configure `Automapper` to use `IoC` for instantiating new objects including Collections. The objective could be summerized as

- Use IoC to instantiate Destination Type when mapped using `Automapper`
- The SourceType-DestinationType mapping would be done only at runtime as and when the requirement arises. It would be NOt be done beforehand using Profile Classses.
- It needs to be ignore all properties from Source which has been decorated with `IgnoreDataMemberAttribute`
- Create a wrapper around Automapper which would enable to accomplish the above mentioned requirements.

For sake of example, we would be using following Nuget Packages
* Automapper 7.0.1
* Caliburn Micro 3.2.0
* Unity 5.11.4
* NUnit 3.12.0

## Writing Test Cases ##

Let us follow *Test Driven Development* for our purpose and begin by writing our test cases.

``` csharp
public void MapperDataTypeWithCollections()
{
    var valueMapper = new ValueMapper();
    var destinationFromIoC = Shared.TestModels.DataTypeWithCollections.Destination.GetInstanceForIoC();
    var userDefinedTypeFromIoC = Shared.TestModels.DataTypeWithCollections.UserDefinedType.GetInstanceForIoC();

    var source = Shared.TestModels.DataTypeWithCollections.Source.GetInstance();
    var destination = valueMapper.Map<Shared.TestModels.DataTypeWithCollections.Source, Shared.TestModels.DataTypeWithCollections.Destination>(source);

    Assert.AreNotSame(source, destination);
    Assert.AreEqual(source.Property1, destination.Property1);

    Assert.AreNotEqual(source.Property2, destination.Property2);
    Assert.AreEqual(destinationFromIoC.Property2, destination.Property2);

    Assert.AreNotSame(source.Property3, destination.Property3);
    Assert.AreEqual(source.Property3.Property1, destination.Property3.Property1);
    Assert.AreNotEqual(source.Property3.Property2, destination.Property3.Property2);
    Assert.AreEqual(userDefinedTypeFromIoC.Property2, destination.Property3.Property2);

    CollectionAssert.AreNotEqual(source.Property4, destination.Property4);
    Assert.AreNotSame(source.Property4, destination.Property4);
    for (int i = 0; i < source.Property4.Count; i++)
    {
        Assert.AreNotSame(source.Property4[i], destination.Property4[i]);
        Assert.AreEqual(source.Property4[i].Property1, destination.Property4[i].Property1);
        Assert.AreNotEqual(source.Property4[i].Property2, destination.Property4[i].Property2);
        Assert.AreEqual(userDefinedTypeFromIoC.Property2, destination.Property4[i].Property2);
    }
}
```
Data Structures used in the above Test Case above are as follows.

```csharp
// Source
public class Source
{
    public string Property1 { get; set; }
    [IgnoreDataMember]
    public string Property2 { get; set; }
    public UserDefinedType Property3 { get; set; }
    public List<UserDefinedType> Property4 { get; set; }

    public static Source GetInstance()
    {
        return new Source
        {
            Property1 = $"{nameof(Source)}.{nameof(Source.Property1)}",
            Property2 = $"{nameof(Source)}.{nameof(Source.Property2)}",
            Property3 = new UserDefinedType 
            { 
                Property1 = $"{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property1)}", 
                Property2 = $"{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property2)}" 
            },
            Property4 = Enumerable.Range(1, 5).Select(x =>
            new UserDefinedType
            {
                Property1 = $"{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property1)}[{x}]",
                Property2 = $"{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property2)}[{x}]"
            }).ToList()
        };
    }
}
// Destination
public class Destination
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
    public UserDefinedType Property3 { get; set; }
    public List<UserDefinedType> Property4 { get; set; }

    public static Destination GetInstanceForIoC()
    {
        return new Destination
        {
            Property1 = $"IoC => {nameof(Destination)}.{nameof(Destination.Property1)}",
            Property2 = $"IoC => {nameof(Destination)}.{nameof(Destination.Property2)}",
            Property3 = UserDefinedType.GetInstanceForIoC(),
            Property4 = Enumerable.Range(1, 5).Select(x =>
            UserDefinedType.GetInstanceForIoC(x)).ToList()
        };
    }
} 
// User Defined Type
public class UserDefinedType
{
    public string Property1 { get; set; }
    [IgnoreDataMember]
    public string Property2 { get; set; }

    public static UserDefinedType GetInstanceForIoC()
    {
        return new UserDefinedType
        {
            Property1 = $"IoC => {nameof(UserDefinedType)}:{nameof(UserDefinedType.Property1)}",
            Property2 = $"IoC => {nameof(UserDefinedType)}:{nameof(UserDefinedType.Property2)}"
        };
    }

    public static UserDefinedType GetInstanceForIoC(int index)
    {
        return new UserDefinedType
        {
            Property1 = $"IoC => {nameof(UserDefinedType)}:{nameof(UserDefinedType.Property1)}[{index}]",
            Property2 = $"IoC => {nameof(UserDefinedType)}:{nameof(UserDefinedType.Property2)}[{index}]"
        };
    }
}
```

## Definition of ValueMapper ##

Let's define how our `ValueMapper` would look like first using the `IValueMapper` interface

### ValueMapper interface ###
```csharp
public interface IValueMapper
{
    TDestination Map<TSource, TDestination>(TSource source);
    TDestination Map<TSource, TDestination>(TSource source,TDestination destination);
}
```

### Use IoC for instantiating Types ###
In order to create the mapping configurations in runtime, we would make use of the `MapperConfiguration` and `MapperConfigurationExpression` classes.

```csharp
private readonly MapperConfigurationExpression _mapperConfigurationExpression = new MapperConfigurationExpression();
private IMapper _mapper;
private MapperConfiguration _mapperConfiguration;
```

We will begin by configuring the *MappingConfigurationExpression* to use IoC.

```csharp
_mapperConfigurationExpression.ConstructServicesUsing(CreateInstance);
```
Where `CreateInstance` is defined as
```csharp
private object CreateInstance(Type type)
{
    try
    {
        return Caliburn.Micro.IoC.GetInstance(type, null);
    }
    catch
    {
        return Activator.CreateInstance(type);
    }
}
```
The `CreateInstance` method is quite self explainatory. If type is not registered with IoC, it attempts to create the type using the default contructor via `Activator.CreateInstance` method.

### Ignore properties with IgnoreDataMemberAttribute ###

Before we put it all together, we need to configure the `Automapper` to skip properties that has been decorated with `IgnoreDataMemberAttribute`.

For this purpose, we will write an extension on `IMappingExpression` type.

``` csharp
public static class IMappingExpressionExtensions
{
    public static IMappingExpression IgnoreAllPropertiesWithIgnoreDataMemberAttribute(
        this IMappingExpression expression, Type sourceType)
    {
        foreach (var property in sourceType.GetProperties().Where(x => x.GetCustomAttributes<IgnoreDataMemberAttribute>().Any()))
        {
            expression.ForMember(property.Name, opt => opt.Ignore());
        }

        return expression;
    }
}
```

As observed, we are iterating through each properties of the Type, and marking the ones with the required Attribute.

The obvious question  at this point would be, if one of the nested child properties of the Source has been decorated with the attribute, that would not be covered by the extension method we just wrote. We will address the problem shortly. For time being, let us use MappingExpressionConfiguration to use the extension method we just created. 

```
_mapperConfigurationExpression.CreateMap(sourceType, destinationType)
                                .IgnoreAllPropertiesWithIgnoreDataMemberAttribute(sourceType)
                                .ConstructUsingServiceLocator();
```

### Putting it all together ###

The next step is to configure the Automapper to use the `MappingConfigurationExpression` we just created(updated).

```csharp
_mapperConfiguration = new MapperConfiguration(_mapperConfigurationExpression);
_mapper = new Mapper(_mapperConfiguration);
```

We now need to ensure that the nested properties are taken care of. We will do so by recursively loop through the properties of Source Type. 

```csharp
private void CreateMap(Type sourceType,Type destinationType)
{
    _mapperConfigurationExpression.ConstructServicesUsing(CreateInstance);

    _mapperConfigurationExpression.CreateMap(sourceType, destinationType)
                                    .IgnoreAllPropertiesWithIgnoreDataMemberAttribute(sourceType)
                                    .IgnoreAllPropertiesWithNoDataMemberWhenTypeHasDataContractAttribute(sourceType)
                                    .ConstructUsingServiceLocator();
    _mapperConfiguration = new MapperConfiguration(_mapperConfigurationExpression);
    _mapper = new Mapper(_mapperConfiguration);

    var sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach(var property in sourceProperties)
    {
        if (property.PropertyType.IsStringOrValueType())
        {
            continue;
        }

        if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
        {
            var elementType = property.PropertyType.GetGenericArguments()[0];
            CreateMap(elementType, elementType);
            continue;
        }

        CreateMap(property.PropertyType, property.PropertyType);
    }
}
```

As can be observed from the code, we are addressing only Public Instance properties for the sake of example. This could be extended for other properties if required.

## Complete ValueMapper Code ##

Complete source code of ValueMapper is shown below.

``` csharp
public class ValueMapper : IValueMapper
{
    private readonly MapperConfigurationExpression _mapperConfigurationExpression = new MapperConfigurationExpression();
    private IMapper _mapper;
    private MapperConfiguration _mapperConfiguration;

    public ValueMapper()
    {
        _mapperConfiguration = new MapperConfiguration(_mapperConfigurationExpression);
        _mapper = _mapperConfiguration.CreateMapper();
    }
    public TDestination Map<TSource, TDestination>(TSource source)
    {
        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);

        CreateMap(sourceType, destinationType);
        return _mapper.Map<TSource, TDestination>(source);

    }
    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);
        CreateMap(sourceType, destinationType);
        return _mapper.Map<TSource, TDestination>(source);
    }
    private void CreateMap(Type sourceType,Type destinationType)
    {
        _mapperConfigurationExpression.ConstructServicesUsing(CreateInstance);

        _mapperConfigurationExpression.CreateMap(sourceType, destinationType)
                                        .IgnoreAllPropertiesWithIgnoreDataMemberAttribute(sourceType)
                                        .IgnoreAllPropertiesWithNoDataMemberWhenTypeHasDataContractAttribute(sourceType)
                                        .ConstructUsingServiceLocator();
        _mapperConfiguration = new MapperConfiguration(_mapperConfigurationExpression);
        _mapper = new Mapper(_mapperConfiguration);

        var sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach(var property in sourceProperties)
        {
            if (property.PropertyType.IsStringOrValueType())
            {
                continue;
            }

            if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                var elementType = property.PropertyType.GetGenericArguments()[0];
                CreateMap(elementType, elementType);
                continue;
            }

            CreateMap(property.PropertyType, property.PropertyType);
        }
    }

    private object CreateInstance(Type type)
    {
        try
        {
            return Caliburn.Micro.IoC.GetInstance(type, null);
        }
        catch
        {
            return Activator.CreateInstance(type);
        }
    }
}
```

### Conclusion ###

The above article uses Automapper 7.0.1 for demonstrating the requirements. The approach could differ when using an older version of Automapper. 

The sample source code along with this article is a WPF Project with Test Cases using NUnit.
