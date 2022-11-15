public class Solution {
  	private Dictionary<char,List<string>> mapping = new Dictionary<char,List<string>>()
	{
		['1'] = new(),
		['2'] = new() {"a","b","c"},
		['3'] = new() {"d","e","f"},
		['4'] = new() {"g","h","i"},
		['5'] = new() {"j","k","l"},
		['6'] = new() {"m","n","o"},
		['7'] = new() {"p","q","r","s"},
		['8'] = new() {"t","u","v"},
		['9'] = new() {"w","x","y","z"}
					
	};
    public IList<string> LetterCombinations(string digits) {
	
		var result = new List<string>();
		var listOfList = GetLists(digits).ToList();
		
		
		if(!listOfList.Any()) return new List<string>();
		//listOfList.Dump();
		foreach(var item in listOfList.First())
		{
			result.AddRange(GetCombinations(item,listOfList.Skip(1).ToList()));
		}
        return result;
    }
	
	private IEnumerable<string> GetCombinations(string currentValue,List<List<string>> lists)
	{
		//new{lists,currentValue}.Dump();
		if(!lists.Any()) 
		{
			yield return currentValue;
			yield break;
		}
		
		if(lists.Count == 1) 
		{
			foreach(var item in lists.First()) 
			{
				yield return $"{currentValue}{item}";;
			}
			yield break;
		}
		
		//lists.First().Dump();
		foreach(var current in lists.First())
		{
			foreach(var item in GetCombinations($"{currentValue}{current}",lists.Skip(1).ToList()))
			{
				yield return $"{item}";
			}
		}
	
	}
	private IEnumerable<List<string>> GetLists(string digits)
	{
		foreach(var c in digits)
		{
			yield return mapping[c];
		}
	}
}