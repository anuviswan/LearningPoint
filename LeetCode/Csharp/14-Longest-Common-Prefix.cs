public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        
            var count = 0;
            var currentPrefix = new StringBuilder();
            
            var smallestWordSize = strs.Min(x=>x.Count());
        
            while(smallestWordSize> 0 && count< smallestWordSize)
            {
                var currentChar = strs[0][count];
                
                if(strs.Select(x=>x[count]).All(x=>x==currentChar))
                {
                    currentPrefix.Append(currentChar);
                    count++;
                }
                else
                {
                    break;
                }
                
            }
        
        return currentPrefix.ToString();
    }
    
    
}