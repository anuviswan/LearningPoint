public class Solution {
 public int RomanToInt(string s) {
        
        return getValue(0,new string(s.Reverse().ToArray()));
    }
    
    int getValue(int currentValue,string s)
    {
        if(s.Length == 0) return currentValue;
        if(s.Length==1) return currentValue + Roman[s[0]];

        
        var current = Roman[s[0]];
        var next = Roman[s[1]];

		
        if(next >= current)
        {
            currentValue += current;
			return getValue(currentValue,s.Substring(1,s.Length-1));
        }
        else
        {
            currentValue -= (next-current);
			return getValue(currentValue,s.Substring(2,s.Length-2));
        }
        
        
    }
    
    Dictionary<char,int> Roman = new Dictionary<char,int>
    {
      ['I'] = 1,
      ['V'] = 5,
      ['X'] = 10,
      ['L'] = 50,
      ['C'] = 100,
      ['D'] = 500,
      ['M'] = 1000
    };  
}