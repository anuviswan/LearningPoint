/*
* Problem Description : https://leetcode.com/problems/longest-substring-without-repeating-characters/
*/


public class Solution {
    public int LengthOfLongestSubstring(string s) 
    {
        var len = s.Length;
        if(len==0 || len==1) return len;
        var map = new Dictionary<char,int>();
        var result=-1;
        var l=-1;
        for(var r=0;r<len;r++)
        {
			
            if(map.ContainsKey(s[r]))
            {
                l = Math.Max(map[s[r]],l);
            }
			
			result = Math.Max(result,r-l);
            map[s[r]]=r;
			
			
        }
        
        
        return  result;
    }
}