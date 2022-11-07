public class Solution {
    public bool IsPalindrome(int x) {
        if(x<0) return false;
        
        var rev = 0;
        var original = x;
        var index = 1;
        while(original>0)
        {
            var remainder = original%10;
            rev = (rev*10) + remainder;
			
            original = original/10;
        }
        
		
        return rev == x;
    }
}