public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
		
		var currentLowest = -1;
		var currentSum = 0;
		
		Array.Sort(nums);
		
		for(int i=0;i<nums.Length;i++)
		{
            if(currentLowest != -1 && Math.Abs(target - currentLowest) < nums[i]) continue;
			for(int j=i+1;j<nums.Length;j++)
			{
                if(currentLowest != -1 && Math.Abs(target - currentLowest) < (nums[i] + nums[j]) )
                    continue;
				for(int k=j+1;k<nums.Length;k++)
				{
					//new {i,j,k, nums.Length}.Dump();
					var tempSum = (nums[i] + nums[j] +nums[k]);
					var tempDiff = target - tempSum;
					//$"{nums[i]},{nums[j]},{nums[k]} => {tempSum}".Dump();
					if(currentLowest == -1)
					{
						currentLowest = tempDiff;
						currentSum = tempSum;
					}
					else if(Math.Abs(tempDiff) < Math.Abs(currentLowest))
					{
						currentLowest = tempDiff;
						currentSum = tempSum;
					}
					else
					{
						continue;
					}
				}
			}
		}
		
		//new{currentSum,currentLowest}.Dump();
        return currentSum;
    }
}