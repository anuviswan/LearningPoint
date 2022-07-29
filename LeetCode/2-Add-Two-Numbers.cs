
/**
 * Problem : https://leetcode.com/problems/add-two-numbers/
 *
 *
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
 
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
var h1 = l1;
	   var h2 = l2;
	   var carry = 0;
	   var result = new ListNode();
	   var currentResultHead = result;
	   
	   while(h1!=null || h2!=null)
	   {
	   		var x = h1?.val ?? 0;
			var y = h2?.val ?? 0;
			
			var sum = x+ y + carry;
			carry = sum/10;
			currentResultHead.next = new ListNode(sum%10);
			currentResultHead = currentResultHead.next;
           
           h1 = h1?.next;
			h2 = h2?.next;
	   }
	   
        if(carry!=0)
        {
            currentResultHead.next = new ListNode(carry);
        }
	   return result.next;
    }
}