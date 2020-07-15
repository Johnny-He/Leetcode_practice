using System;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetcodeTest83
    {
        [Test]
        public void remove_duplicates_from_sorted_list()
        {
            var leetCode = new Leetcode();
            var headNode = SetUpListNode();
            DisplayNode(headNode);
            var removeDuplicateList = leetCode.DeleteDuplicates(headNode);
            Console.WriteLine("===================");
            DisplayNode(headNode);

        }
        private void DisplayNode(Node headNode, int number = 1)
        {
            Console.WriteLine($"number = {number}, value = {headNode.val}");
            if (headNode.next != null)
            {
                DisplayNode(headNode.next, number + 1);
            }
        }
        private Node SetUpListNode()
        {
            var headNode3 = new Node
            {
                val = 1,
                next = null
            };
            var headNode2 = new Node
            {
                val = 1,
                next = headNode3
            };
            var headNode = new Node
            {
                val = 1,
                next = headNode2
            };
            return headNode;
        }
    }

    public class Leetcode
    {
        public Node DeleteDuplicates(Node head)//add preNode
        {
            if (head == null)
            {
                return null;
            }
            
            if (head.next != null && head.val == head.next.val)
            {
                head.next = head.next.next;
                DeleteDuplicates(head);
            }
            else
            {
                DeleteDuplicates(head.next);
            }


            return head;

        }
    }

    public class Node
    {
        public int val { get; set; }
        public Node next { get; set; }
    }


}