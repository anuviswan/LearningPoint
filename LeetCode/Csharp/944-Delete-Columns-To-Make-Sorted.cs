public class Solution {
    public int MinDeletionSize(string[] strs) {
        var length = strs[0].Length;
		var columnCount = 0;
		
		for(var i=0;i<length;i++)
		{
			var lastChar = strs[0][i];
			
			foreach(var str in strs)
			{
				var currentChar = str[i];
				if(currentChar < lastChar)
				{
					columnCount++;
					break;
				}
				else
				{
					lastChar = currentChar; 
				}
			}
			
		}
		
		return columnCount;
    }
}