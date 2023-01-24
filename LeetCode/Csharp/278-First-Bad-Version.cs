public class Solution :VersionControl {
    public int FirstBadVersion(int n) {
        if(n==1) return 1;
		
		return Find(0,n,-1);		
    }
	
	private int Find(int min,int max,int prev)
	{
		var mid = min + (max - min )/2;
		if(min == max) return IsBadVersion(min) ? min:prev;
		
		if(IsBadVersion(mid))
		{
			
			if(prev == -1 || mid < prev)
				prev = mid;
				
			return Find(min,mid,prev);
		}
		else
		{
			return Find(mid+1,prev == -1 ? max:prev,prev);
		}
	}
	

}