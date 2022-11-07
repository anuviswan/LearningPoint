using System.Text.RegularExpressions;


public class Solution {
    public int MyAtoi(string s) {
        
        var value = 0;
        var trimmedString = s.Trim();
        
        if(trimmedString.Length == 0) return value;
        
        var regex = new Regex(@"(?<CharSet1>[a-zA-Z]*)(?<Sign>[+-]?)(?<Number>\d*)");
        
        
        var match = regex.Match(trimmedString);
        
        if(!string.IsNullOrEmpty(match.Groups["CharSet1"].Value)) return 0;
		var sign = match.Groups["Sign"].Value == "-" ? -1:1;
		
		if(!Int64.TryParse(match.Groups["Number"].Value,out var longValue))
		{
            if(string.IsNullOrEmpty(match.Groups["Number"].Value)) return 0;
            
            if(sign == -1) return Int32.MinValue;
            return Int32.MaxValue;
		}
		longValue = sign * longValue;
		
		if(longValue > Int32.MaxValue) return Int32.MaxValue;
		if(longValue < Int32.MinValue) return Int32.MinValue;

		return  (int)longValue;
    }
}
