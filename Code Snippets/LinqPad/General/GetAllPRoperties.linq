<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Reference Relative="..\..\..\..\MockCollection\Randomize\bin\Debug\Randomize.Net.dll">E:\App Store\GitHub\anuviswan\MockCollection\Randomize\bin\Debug\Randomize.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Expressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Reflection.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>C:\Users\Jia\source\WebApplication2\bin\System.Web.Helpers.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Serialization.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Randomize.Net</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Printing</Namespace>
  <Namespace>System.Dynamic</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq.Expressions</Namespace>
  <Namespace>System.Management</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.ServiceModel</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web.Helpers</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
	var foo = new Foo
	{
		Reference = $"{nameof(Foo)}.{nameof(Foo.Reference)} Value",
		Company = new CompanyModel
		{
			Name =  $"{nameof(Foo)}.{nameof(CompanyModel)}.{nameof(CompanyModel.Name)} Value",
		},
		CallData = new CallDataModel
		{
			Item = Enumerable.Range(1,10).Select(x=> new CallModel{Name= $"{nameof(Foo)}.{nameof(CallModel)}.{nameof(CallModel.Name)} {x}",Value= x})
		},
	};
	GetProperties(foo);
	
}

public class Boo
{
	public IEnumerable<int> abc {get;set;}
}

public class Foo
{
    public string Reference { get; set; }
    public CompanyModel Company { get; set; }
    public CallDataModel CallData { get; set; }
}

public class CompanyModel
{
    public string Name { get; set; }
}

public class CallDataModel
{
    public IEnumerable<CallModel> Item { get; set; }
}

public class CallModel
{
    public string Name { get; set; }
    public int Value { get; set; }
}

// Define other methods and classes here
 private static void GetProperties<T>(T obj)
{
    if (obj == null) return;
    Type objType = obj.GetType();
    
    PropertyInfo[] properties = obj.GetType().GetProperties();
    foreach (PropertyInfo property in properties)
    {
        if (property.IsEnumerable())
        {
			if(property.GetValue(obj,null) is IEnumerable elems)
			{
                foreach (var item in elems)
                {
                    GetProperties(item);
                }
			}
        }
        else
        {
			var propValue = property.GetValue(obj, null);
            if (property.PropertyType.Assembly == objType.Assembly)
            {
                GetProperties(propValue);
            }
            else
            {
				Console.WriteLine($"{property.Name} = {propValue}");
            }
			
        }
    }
}
		
		
public static class Extensions
{
	public static bool IsEnumerable(this PropertyInfo propertyInfo)
	{
		if(!propertyInfo.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)) )
		{
			return false;
			
		}
		return propertyInfo.PropertyType != typeof(String);
	}
}