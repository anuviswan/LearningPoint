public class Solution {
    public int MaxArea(int[] height) {
        
        var currentMaxHeight = 0;
		var maxVolume= 0;
        
        var right = height.Length - 1;
        var left = 0;
        
        while(left<right)
        {
            var volume = new  Volume
            {
                Height = Math.Min(height[right],height[left]),
                Width = right - left
            };
            
            
            if(height[right] < height[left])
            {
                right--;
            }
            else 
            { 
                left++;
            }
            
            if(maxVolume < volume.Area)
            {
                maxVolume = volume.Area;
            }
        }
        
        
		return maxVolume;        
    }
    
    
    private class Volume
    {
        public int Height{get;set;}
        public int Width {get;set;}
		
		public int Area => Height * Width;
        
    }
}