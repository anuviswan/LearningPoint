public class Solution {
    public string LongestPalindrome(string s) 
    {
       var left = 0;
        var length = 0;
        var l = s.Length;
        for(int i=0;i<l;i++)
        {
            var l1 = PalindromeInternal(s,i,i);
            var l2 = PalindromeInternal(s,i,i+1);
            var c = Math.Max(l1,l2);
            if(c>length)
            {
                left = i-(c-1)/2;
                length = c;
            }
        }
        
		
        return s.Substring(left,length);
    }
    
    private int PalindromeInternal(string s,int left, int right)
    {
        var m = s.Length;
        while(left>=0 && right <m && s[left] == s[right])
        {
            left--;
            right++;
        }
		
        return (right - (left+1)) ;
    }
}