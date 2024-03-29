<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Reference>E:\App Store\GitHub\anuviswan\MockCollection\Randomize\bin\Debug\Randomize.Net.dll</Reference>
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
  <Namespace>System.Management</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

public static class EnumerableExtensions
{
    public static IEnumerable<T> Append<T>(this IEnumerable<T> source,T item)
	{
		foreach(var currentItem in source)
		{
			yield return currentItem;
		}
		
		yield return item;
	}
	public static IEnumerable<T> Insert<T>(this IEnumerable<T> source,int position,T item)
	{
		var currentPosition = -1;
		
		using(var iterator = source.GetEnumerator())
		{
			while(++currentPosition < position && iterator.MoveNext())
			{
				yield return iterator.Current;
			}
			
			if(currentPosition < position)
			{
				throw new ArgumentOutOfRangeException("Invalid Position");
			}
			
			yield return item;
			
			while(iterator.MoveNext())
				yield return iterator.Current;
			
		}
		
	}
}