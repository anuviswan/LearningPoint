public class Solution {
    public bool IsValid(string s) {
        
        var stack = new Stack<char>();
        foreach(var ch in s)
        {
            if(stack.Count>0 && stack.Peek()==ch)
            {
                stack.Pop();    
            }
            else
            {
                try
                {
                    var closingChar = ch switch
                    {
                            '{' => '}',
                            '('=> ')',
                            '[' => ']',
                            _ => throw new Exception()
                    };
                    stack.Push(closingChar);
                }
                catch
                {
                    return false;                    
                }
                
            }
        }
        
        return !stack.Any();
    }
}