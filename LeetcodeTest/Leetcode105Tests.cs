using System.Collections;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode105Test
    {
        [Test]
        public void test()
        {
            var leetCode105 = new LeetCode105();

            // var nthUglyNumber = leetCode105.NthUglyNumber(137);
            // nthUglyNumber.Should().Be(4096);
        }
    }

    public class LeetCode105
    {
        // Input: preorder =[3,9,20,15,7],
        //        inorder = [9,3,15,20,7]
        // Output: [3,9,20,null,null,15,7]
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var hashtable = new Hashtable();
            for (int i = 0; i < inorder.Length; i++)
            {
                hashtable.Add(inorder[i],i);
            }

            return dfs(preorder, hashtable, 0, preorder.Length - 1, 0, inorder.Length - 1);
        }

        private TreeNode dfs(int[] preorder, IDictionary inorderLookup, int preorderLeft, int preorderRight, int inoderLeft,
            int inorderRight)
        {
            if (inoderLeft > inorderRight)
            {
                return null;
            }
            var root = new TreeNode(preorder[preorderLeft]);
            var rootPosition = (int)inorderLookup[root.val];
            var leftSubtreeLength = rootPosition - inoderLeft;

            root.left = dfs(preorder, inorderLookup, preorderLeft + 1, preorderLeft + leftSubtreeLength, inoderLeft,
                rootPosition - 1);
            root.right = dfs(preorder, inorderLookup, preorderLeft + leftSubtreeLength + 1, preorderRight,
                rootPosition + 1, inorderRight);
            return root;
        }
    }
}