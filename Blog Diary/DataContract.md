Serialization at times throws curious situations that makes us look beyond the normal usages. Here is another situation that took sometime to find a solution for. Let's examine the following code.

``` csharp
public class Test:BaseClass
{
	public string Name {get;set;}
}

[DataContract]
public class BaseClass
{
}
```

What would be the output if one was to serialize an instance of the Test class ? 

``` csharp
var instance = new Test{Name="abc"};
var result = JsonConvert.SerializeObject(instance);
```
Let's examine the output
```
{}
```
Not surprising right ? After all the base class has been decorated with `DataContractAttribute`. This would ensure the only the members (or members of derieved classes) with `DataMemberAttribute` would be serialized.

As seen in the code above, while the base class doesn't have any property, the child class has a single property (Name), which is NOT decorated with the mentioned attribute. 

This is as per the design and works well in most cases. If one needs to be ensure the Child class members needs to be serialized, one needs to decorate it with the `DataMemberAttribute`. 

``` csharp
public class Test:BaseClass
{
	[DataMember]
	public string Name {get;set;}
}

[DataContract]
public class BaseClass
{
}
```

This would ensure the Property `Name` is serialized.
```
{"Name":"abc"}
```

The other option he have is to remove the `DataContractAttribute` from the BaseClass, which would produce the same result.

But what if the Developer have following constrains
* Cannot access/change the `BaseClass`
* Should not use the `DataMemberAttribute`

The second property is chiefly driven by the factor that there are many Properties in the Child Class. This would require the developer to use the `DataMemberAttribute` on each of them, which is quite painful and naturally, one would want to avoid it.

The solution lies in a lesser known Property of the well known `JsonObjectAttribute`. The `MemberSerialization.OptOut` enumeratation ensures the following behavior.

>All public members are serialized by default. Members can be excluded using JsonIgnoreAttribute or NonSerializedAttribute.


While this is the default member serialization mode, this gets overriden due the presence of `DataContractAttribute` in the Parent Class.

Let's modify our code again.
``` csharp
[JsonObject(MemberSerialization.OptOut)]
public class Test:BaseClass
{
	public string Name {get;set;}
}

[DataContract]
public class BaseClass
{
}
```
As seen the code above, the only change required would be decorated the Child Class with `JsonObjectAttribute` passing in the `MemberSerialization.OptOut` Enumeration for Member Serialization Mode.

This would produce the desired output
```
{"Name":"abc"}
```