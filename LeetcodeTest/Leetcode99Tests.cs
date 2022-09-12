using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode99Test
    {
        [Test]
        public void test()
        {
            //[5,3,6,2,4,null,null,1]
       
            
        }
    }

    public class LeetCode99
    {
        public TreeNode ParseList(List<string> s)
        {
            if (s == null)
            {
                return null;
            }
            var treeNode = new TreeNode
            {
                val = int.Parse(s[0]),
                left = AssignLeft(s.Skip(0).ToList()),
                right = AssignLeft(s.Skip(1).ToList())
            };
            

            return treeNode;
        }

        private TreeNode AssignLeft(List<string> stringList)
        {
            if (stringList[0] == null && stringList[1] == null)
            {
                return null;
            }
            // return new 
            throw new System.NotImplementedException();
        }

        public int KthSmallest(TreeNode root, int k)
        {
            var min = 0;
            var ints = new List<int>();
            GoThoughtBinaryTree(root, ints);
            ints.Sort();

            return ints[k-1];
        }

        private void GoThoughtBinaryTree(TreeNode treeNode, List<int> treeValues)
        {
            if (treeNode == null)
            {
                return;
            }
            
            treeValues.Add(treeNode.val);
            if (treeNode.left == null && treeNode.right == null)
            {
                return;
            }

            GoThoughtBinaryTree(treeNode.left, treeValues);
            GoThoughtBinaryTree(treeNode.right, treeValues);
        }
        
    }

  
}