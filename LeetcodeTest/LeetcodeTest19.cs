using System;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetcodeTest19
    {
        [Test]
        public void remove_Nth_node_from_end_of_list()
        {
            var leetCode19 = new Leetcode19();
            var headNode = SetUpListNode();
            var oneListNode = SetUpOneListNode();

            var target = 2;
            DisplayNode(oneListNode, 1);
            Console.WriteLine("=========================");
            //var removeNthFromEnd = leetCode19.RemoveNthFromFirst(headNode, 2);
            var removeNthFromEnd = leetCode19.RemoveNthFromEnd(oneListNode, 1);
            DisplayNode(removeNthFromEnd, 1);
        }

        [Test]
        public void METHOD()
        {
            
        }

        private ListNode SetUpTwoListNode()
        {
            var listNode2 = new ListNode
            {
                val = 2,
                next = null
            };
            var listNode = new ListNode
            {
                val = 1,
                next = listNode2
            };
            return listNode;
        }

        private ListNode SetUpOneListNode()
        {
            var listNode = new ListNode
            {
                val = 1,
                next = null
            };
            return listNode;
        }

        private void DisplayNode(ListNode headNode, int number)
        {
            Console.WriteLine($"number = {number}, value = {headNode.val}");
            if (headNode.next != null)
            {
                DisplayNode(headNode.next, number + 1);
            }
        }

        private ListNode SetUpListNode()
        {
            var headNode5 = new ListNode
            {
                val = 5,
                next = null
            };
            var headNode4 = new ListNode
            {
                val = 4,
                next = headNode5
            };
            var headNode3 = new ListNode
            {
                val = 3,
                next = headNode4
            };
            var headNode2 = new ListNode
            {
                val = 2,
                next = headNode3
            };
            var headNode = new ListNode
            {
                val = 1,
                next = headNode2
            };
            return headNode;
        }

    }

    public class Leetcode19
    {
        public void RemoveNthFromFirst(ListNode head, int n, int target)
        {
            if (target == n)
            {
                head.val = 100;
                head = null;
            }
            if (n == target - 1)
            {
                head.next = head.next.next;
            }
            else if (n != target)
            {
                RemoveNthFromFirst(head.next, n + 1, target);
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var nodeCount = GetNodeCount(head, 1);
            var numFromFirst = nodeCount - n + 1;
            Console.WriteLine($"nodeCount =  {nodeCount} ,numFromFirst = {numFromFirst}");
            RemoveNthFromFirst(head, 1, numFromFirst);

            return head;
        }

        private int GetNodeCount(ListNode head, int n)
        {
            if (head.next == null)
            {
                return n;
            }
            return GetNodeCount(head.next, n + 1);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}