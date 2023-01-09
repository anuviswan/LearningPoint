using System.Text.RegularExpressions;

public class Solution {
    public bool DetectCapitalUse(string word) {
        if(Regex.IsMatch(word,"^([A-Z]*)$")) return true;
        if(Regex.IsMatch(word,"^([a-z]*)$")) return true;
		if(Regex.IsMatch(word,"^([A-Z][a-z]*)$")) return true;
        
        return false;
    }
}