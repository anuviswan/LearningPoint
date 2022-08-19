public class Solution {
    public string Convert(string s, int numRows) {
     
        var isOdd = numRows % 2;
        var length = s.Length;
        var maxRows = numRows;
        var maxCols = length;
     
		if(length == 1 || numRows == 1) return s;
        
        var arr = new char[maxRows,maxCols];
        
        int currentRow = 0;
        int currentCol = 0;
        int dir = 1;
        foreach(var ch in s)
        {

            arr[currentRow,currentCol] = ch;
			
            if(currentRow== maxRows-1)
            {
                dir = -1;
            }
            else if(currentRow == 0)
            {
                dir = 1;
            }
            
            currentRow = currentRow + dir;
			if(dir == -1)
			currentCol++;
        }
        
        return ToString(arr,maxRows,maxCols);
        
    }
    
    private string ToString(char[,] arr,int maxRows, int maxCols){
        var strB = new StringBuilder();
        for(int i=0;i<maxRows;i++)
        {
            for(int j=0;j<maxCols;j++)
            {
                if(IsValidCharacter(arr[i,j]))
                strB.Append(arr[i,j]);
            }
        }
        return strB.ToString();
    }
    
    
    private bool IsValidCharacter(char ch)
    {
        
        
        return ((ch>='a' && ch<='z') ||
          (ch>='A' && ch<='Z') || (ch == ',' || ch=='.'));
    }
}