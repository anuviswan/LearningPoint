public class Solution {
    public bool WordPattern(string pattern, string s) {
        
		var distinctWords = s.Split(" ").Distinct().ToList();
		var distinctChars = pattern.Distinct().ToList();
		
		var mapping = distinctWords.Zip(distinctChars,(x,y)=> new {Key = x, Value = y}).ToDictionary(x=>x.Key,y=>y.Value);
		
		var currentPattern = string.Join("",s.Split(" ").Select(x=> 
		{
			if(mapping.TryGetValue(x,out var value)) return value;
			
			return '-';
		}));
		
		return currentPattern == pattern;
    }
}