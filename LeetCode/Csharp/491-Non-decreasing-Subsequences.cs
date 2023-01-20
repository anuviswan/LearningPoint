public class Solution {

    public IList<IList<int>> FindSubsequences(int[] nums) {
	     
		var hash = new Dictionary<string,IList<int>>();
		double maxPowerSet = Math.Pow(2,nums.Length);
		
		for(int i=0;i<maxPowerSet;i++)
		{
			var current = new List<int>();
			var binary = Convert.ToString(i,2).PadLeft(nums.Length,'0');
			
			for(int j=0;j<nums.Length;j++)
			{
				if(binary[j] == '1')
				{
				
					if(!current.Any())
						current.Add(nums[j]);
					else if(current.Last() <= nums[j])
						current.Add(nums[j]);

				}
				
			}
			if(current.Count>=2)
			{
				var key = string.Join(',',current);
				if(!hash.ContainsKey(key))
					hash.Add(string.Join(',',current), current);
					
			}
		}
		
		return hash.Values.ToList();
    }

}