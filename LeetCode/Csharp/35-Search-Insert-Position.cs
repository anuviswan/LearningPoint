public class Solution {
    public int SearchInsert(int[] nums, int target) {
	
	
        if(nums.Length == 1)
		{
			if(nums[0] == target) return 0;
			else return nums[0] > target ? 0: 1;
		}
		
		return Find(nums,target,0,nums.Length-1,-1);
    }
	
	private int Find(int[] nums,int target,int min,int max,int prev)
	{
		var mid = min + (max - min) /2;
		//new {target,min,mid,max,prev}.Dump();
		if(min == max && nums[min] != target)
		{
			if(nums[min]>target)
				return min;
			else
				return min+1;
		}
		
		
		if(nums[mid] == target)
			return mid;
		
		
			
		prev = mid;
		if(nums[mid]> target)
		{
			return Find(nums,target,min,mid,prev);
		}
		else
		{
			return Find(nums,target,mid+1,max,prev);
		}
	}
}

