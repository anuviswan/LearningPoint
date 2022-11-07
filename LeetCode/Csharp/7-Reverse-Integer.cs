public class Solution {
    public int Reverse(int x) 
    {
        int rev = 0;
        int maxValue = Int32.MaxValue;
        int minValue = Int32.MinValue;
		
        int sign = x<0?-1:1;
	
        while(x!=0)
        {
            var n = x%10;
            x = x/10;
            
            if(sign>0)
            {
                if(rev>maxValue/10 || (rev==maxValue/10 && n>7)) return 0;
            }
            else
            {
                if(rev<minValue/10 || (rev==minValue/10 && n< minValue%10)) return 0;
            }
            
            
            rev = rev* 10 + n;
        }

        
        return rev;
    }
}