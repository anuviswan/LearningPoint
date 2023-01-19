public class Solution {
    public int SubarraysDivByK(int[] nums, int k) 
	{
		var result = 0;
		var mapping = new Dictionary<int,int>();
		mapping.Add(0,0);
		var sum = 0;
		
		for(int i=0;i<nums.Length;i++)
		{
			sum += nums[i];
			var mod = sum % k < 0 ? (sum % k + k):(sum % k);
			
			if(mapping.ContainsKey(mod))
			{
				mapping[mod] += 1;
			}
			else
			{
				mapping[mod] = 1;
			}
		}
    	
		//mapping.Dump();
		result = mapping.Where(x=> x.Value != 1).Select(x=>(x.Value*(x.Value-1))/2).Sum() + mapping[0];
		return result;
    }
}