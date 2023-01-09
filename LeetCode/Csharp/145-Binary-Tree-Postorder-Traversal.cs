/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
		   return Traverse(root).ToList();     
    }
	
	public IEnumerable<int> Traverse(TreeNode node)
	{
		if(node == null) yield break; 
		
		
		foreach(var val in Traverse(node.left)) yield return val;
		foreach(var val in Traverse(node.right)) yield return val;
        yield return node.val;
	}
}