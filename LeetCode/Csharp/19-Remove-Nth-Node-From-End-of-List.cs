public class Solution 
{

	public ListNode RemoveNthFromEnd(ListNode head, int n) 
	{
		var stack = new Stack<int>();
		while(head.next != null)
		{
		    stack.Push(head.val);
			head = head.next;
		}
		
		stack.Push(head.val);
		
		var indexToRemove = stack.Count - n;
		
		ListNode current = null;
        
		while(stack.Count != 0)
		{
			var val = stack.Pop();
			if(stack.Count != indexToRemove)
			{
				current = new ListNode(val,current);
			}
		}
		
    	return current;
	}
}