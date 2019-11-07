<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Reference Relative="..\..\..\..\MockCollection\Randomize\bin\Debug\Randomize.Net.dll">E:\App Store\GitHub\anuviswan\MockCollection\Randomize\bin\Debug\Randomize.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Expressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Serialization.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Randomize.Net</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Dynamic</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Linq.Expressions</Namespace>
  <Namespace>System.Management</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
	var str = @"{
    'filter': [
        {
            'andOr': '',
            'openCondition': false,
            'columnName': 'accountName',
            'operator': 'eq',
            'value': 'KATHERINE',
            'closeCondition': false
        }
    ],
    'sort': {
            'accountName': 'asc',
            'tradeDate': 'desc'       
    },
    'pageIndex': 1,
    'pageSize': 75
}";

var result = JsonConvert.DeserializeObject<RootObject>(str);
result.Dump();
JsonConvert.SerializeObject(result).Dump();
}

public class Filter
{
    public string andOr { get; set; }
    public bool openCondition { get; set; }
    public string columnName { get; set; }
    public string @operator { get; set; }
    public string value { get; set; }
    public bool closeCondition { get; set; }
}

public class Sort
{
    [JsonExtensionData]
	public Dictionary<string,object> RandomKeyValuePair {get;set;}
}

public class RootObject
{
    public List<Filter> filter { get; set; }
    public Sort sort { get; set; }
    public int pageIndex { get; set; }
    public int pageSize { get; set; }
}
