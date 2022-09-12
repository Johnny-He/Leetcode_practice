using System;

namespace LeetCodeTest.Helper
{
    public class ListNodeHelper
    {
        public ListNode Generate5ListNode()
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
        public void showListNode(ListNode l1)
        {
            while (true)
            {
                Console.Write(l1.val + " ");
                if (l1.next == null)
                {
                    break;
                }
                l1 = l1.next;
            }
        }

    }
}