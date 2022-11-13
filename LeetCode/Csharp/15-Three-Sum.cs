public class Solution {
     public IList<IList<int>> ThreeSum(int[] nums) 
	{
	
		if(nums.Count() < 3) return default;
           
        if(nums.Length == 3) 
		{
			if(nums[0] + nums[1] + nums[2] == 0 )
			{
				return new List<IList<int>> { new List<int> {nums[0],nums[1],nums[2]}};
			}
		}
		
		
		//var orderedItems = Array.Sort(nums);
		Array.Sort(nums);
		var orderedItems = nums;
		var result = new Dictionary<string,IList<int>>();
		
		for(int i=0;i<orderedItems.Length;i++)
		{
			var first = orderedItems[i];
			for(int j=i+1;j<orderedItems.Length;j++)
			{
				var second = orderedItems[j];
				var target = -1* (first + second);
				var key = $"{first},{second},{target}";
				
				if(result.ContainsKey(key)) continue;
				
				var thirdIndex = BinarySearch(orderedItems,j+1, orderedItems.Length - 1 ,target);
				if(thirdIndex != -1)
				{
					result[key] = (new List<int>(){first,second,target});
				}
			}
		}
		
		return result.Values.ToList();
    }

	int BinarySearch(int[] items, int min, int max, int target)
	{

		if(min > max) return -1;
		
		var mid = (min + max)/2;
		var midItem = items[mid];
		
		if(midItem == target) return mid;
		
		return (midItem > target) ? BinarySearch(items,min, mid-1,target)
								   :BinarySearch(items,mid+1, max,target);
	
	}
}