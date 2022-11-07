public class Solution {
    public string IntToRoman(int num) {
        
        if ((num < 0) || (num > 3999)) throw new ArgumentOutOfRangeException();
        if (num < 1) return string.Empty; 
        
        if(num >=1000) return $"M{IntToRoman(num-1000)}";
        if(num >=900) return $"CM{IntToRoman(num-900)}";
        if(num >=500) return $"D{IntToRoman(num-500)}";
        if(num >=400) return $"CD{IntToRoman(num-400)}";
        if(num >=100) return $"C{IntToRoman(num-100)}";
        if(num >=90) return $"XC{IntToRoman(num-90)}";
        if(num >=50) return $"L{IntToRoman(num-50)}";
        if(num >=40) return $"XL{IntToRoman(num-40)}";
        if(num >=10) return $"X{IntToRoman(num-10)}";
        if(num >=9) return $"IX{IntToRoman(num-9)}";
        if(num >=5) return $"V{IntToRoman(num-5)}";
        if(num >=4) return $"IV{IntToRoman(num-4)}";
        if(num >=1) return $"I{IntToRoman(num-1)}";
        throw new ArgumentOutOfRangeException();
    }
}