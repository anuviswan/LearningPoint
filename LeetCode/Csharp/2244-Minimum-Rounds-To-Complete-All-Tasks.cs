public class Solution {
    public int MinimumRounds(int[] tasks) {
        var mapping = tasks.GroupBy(x=>x).ToDictionary(x=>x.Key,y=>y.Count());
		
		if(mapping.Values.Any(x=>x<2)) return -1;
		return  mapping.Values.Select(x=> (x/3) + ((x%3)==0?0:1)).Sum();
    }
}