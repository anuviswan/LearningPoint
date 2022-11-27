public class Solution 
{
	public IList<IList<int>> FourSum(int[] nums,int target) 
	{
		Array.Sort(nums);
		var result = new Dictionary<string,IList<int>>();

		foreach(var item in KSum(nums,4,target))
		{
			var key = string.Join(",",item);
			if(!result.ContainsKey(key))
			{
				result.Add(key,item);
			}
		}
		
		return result.Values.ToList();
	}

	public IEnumerable<IList<int>> KSum(int[] nums,int k,int target)
	{
		if(k<2 || nums.Length < 2) yield break;
		
		if(k==2) 
		{
			// we have reduced the problem to a 2-Sum Problem. Find pairs now.
			foreach(var subResult in TwoSum(nums.ToArray(),target))
			{
				yield return subResult;
			}
		}
		
		else
		{
			for(int i=0;i<nums.Length;i++)
			{
				// This is to check overflow arithmetic exceptions
				if(!IsValidRange(target, nums[i])) yield break;
				
				// Reduce to a K-1 Problem
				foreach(var subResult in KSum(nums.Skip(i+1).ToArray(),k-1,target-nums[i]))
				{
					if(subResult.Any())
					{
						var result = new List<int>();
						result.Add(nums[i]);
						result.AddRange(subResult);
						yield return result;
					}
				}
			}
		}
	}

public IEnumerable<int[]> TwoSum(int[] items, int target)
{

	Dictionary<int,int> mapping = new ();
	for(int i=0;i<items.Length;i++)
	{
		var expected = target- items[i];;
		if(mapping.TryGetValue(expected, out var val))
		{
			yield return new int[]{items[i], expected};
		}

		mapping[items[i]] = expected;
	}
}

	private bool IsValidRange(int first,int second)
	{
		var temp = (long)first - (long)second;
		return (temp < Int32.MaxValue && temp > Int32.MinValue);
	}
}