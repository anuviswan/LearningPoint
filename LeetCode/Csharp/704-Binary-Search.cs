public class Solution {
    public int Search(int[] nums, int target) {
        
		return SearchInternal(nums,0,nums.Length,target);
    }
	
	
	private int SearchInternal(int []nums,int min,int max,int target)
	{
		
		if(min == max) return -1;
		var mid = (max+min)/2;
		
		
		if(nums[mid]==target)
			return mid;
		else
		{
			if(nums[mid] > target)
				return SearchInternal(nums,min,mid,target);
			else
				return SearchInternal(nums,mid+1,max,target);
		}
	}
}