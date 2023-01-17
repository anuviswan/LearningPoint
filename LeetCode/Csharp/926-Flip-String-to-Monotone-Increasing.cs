public class Solution {
    public int MinFlipsMonoIncr(string s) {
    	var countOne = 0;
		var countFlip = 0;
		
		foreach(char c in s)
		{
			if(c == '1')
				countOne++;
			else
			{
				countFlip = Math.Min(++countFlip,countOne);
			}
		}
		
		return countFlip;
	}
}