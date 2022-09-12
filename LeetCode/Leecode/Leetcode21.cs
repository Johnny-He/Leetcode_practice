using System.Collections.Generic;
using Leetcode.Models;

namespace LeetcodeTest
{
    class Leetcode21
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var list1 = new List<int>();
            var check = 0;
            while (l1 != null && l2 != null)  
            {
                if (check != 1)
                {
                    list1.Add(l1.val);
                }
                if (check != 2)
                {
                    list1.Add(l2.val);
                }

                if (l1.next != null)
                {
                    l1 = l1.next;
                }
                else if (check == 2)
                {
                    break;
                }
                else
                {
                    check = 1;
                }
                if (l2.next != null)
                {
                    l2 = l2.next;
                }
                else if (check == 1)
                {
                    break; 
                }
                else
                {
                    check = 2;
                }

            }
            list1.Sort();
            return AddListNode(list1); 
        }

        public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            ListNode ans = null;
            if (l1.val < l2.val)
            {
                ans.val = l1.val;
                ans.next = MergeTwoLists2(l1.next, l2);
            }
            else
            {
                ans.val = l2.val;
                ans.next = MergeTwoLists2(l1, l2.next);
            }

            return ans;
        }

        public ListNode AddListNode(List<int> list)
        {
            var listnode = new ListNode(list[0]);
            var temp = listnode;
            for (int i = 1; i < list.Count; i++)
            {
                temp.next = new ListNode(list[i]);
                temp = temp.next;
            }
            return listnode;

        }
    }

}
