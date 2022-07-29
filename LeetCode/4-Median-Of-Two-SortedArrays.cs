/*
* Problem Description : https://leetcode.com/problems/median-of-two-sorted-arrays/
*/

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        var l1 = nums1.Length;
        var l2 = nums2.Length;
        var expectedLength = (l1+l2)/2;
        
        
        if(l1==0 && l2==0)
        {
		
            return 0;
        }
        
        return expectedLength switch 
        {
            var _ when l1==0 && l2 ==0 =>0,
            var _ when l1==0 && l2 >= 1=>GetMedian(nums2),
            var _ when l2==0 && l1 >= 1=>GetMedian(nums1),
            _=>GetMedian(nums1,nums2)
        };
		
		
        
     
    }
    private double GetMedian(int []nums1,int []nums2)
    {
	
        var l1 = nums1.Length;
        var l2 = nums2.Length;
        var expectedLength = (l1+l2)/2;
        
        var h1 = 0;
        var h2 = 0;
        var arr = new int[expectedLength+1];
        
        for(int i=0;i<expectedLength+1;i++)
        {
			if(h2<l2 && h1<l1)
			{
				if(nums1[h1]>nums2[h2])
	            {
	                arr[i] = nums2[h2];
	                h2++;
	            }
	            else
	            {
	                arr[i] = nums1[h1];
	                h1++;
	            }
			}
			else
			{
				if(h1>=l1)
				{
					arr[i]=nums2[h2];
					h2++;
				}
				else
				{
					arr[i]=nums1[h1];
					h1++;
				}
			}
            
			
        }
        
        if((l1+l2)%2==1) return arr[expectedLength];
        
        return (double)(arr[expectedLength-1] + arr[expectedLength])/2;
        
    }
    private double GetMedian(int []num)
    {
        var l = num.Length/2;
        
        if(l==0) return num[0];
        
        if(num.Length%2==0)
        {
            return (double)(num[l-1] + num[l])/2;
        }
        
        return num[l];
    }
}