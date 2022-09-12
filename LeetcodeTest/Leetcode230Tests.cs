using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FluentAssertions;
using LeetCodeTest.Helper;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode230Test
    {
        [Test]
        public void test()
        {
            //[5,3,6,2,4,null,null,1]
            var treeNode = new TreeNode()
            {
               val =  5,
               left = new TreeNode
               {
                   val = 3,
                   left = new TreeNode
                   {
                       val = 2,
                       left = new TreeNode()
                       {
                           val = 1
                       },
                   },
                   right = new TreeNode
                   {
                       val = 4,
                   }
               },
               right = new TreeNode()
               {
                   val = 6
               }
            };
            var output = new Solution().KthSmallest(treeNode, 3);
            output.Should().Be(3);
        }
    }

    public class Solution
    {
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

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public TreeNode()
        {
            
        }
    }
}