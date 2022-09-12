using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public class Leetcode2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var list1 = sum(l1);
            var list2 = sum(l2);
            var ans = new List<int>();
            var max = list1.Count > list2.Count ? list1 : list2;
            var min = list1.Count < list2.Count ? list1 : list2;
            var remain = 0;
            var n = 0;
            while ( n< max.Count )
            {
                var sum = 0 + remain;
                if (n <min.Count )
                {
                    sum = sum + list1[n];
                    sum = sum + list2[n];
                    n++;
                }
                else 
                {
                    sum = sum + max[n];
                    n++;
                }
                if (sum >= 10)
                {
                    ans.Add(sum - 10);
                    if (n> max.Count - 1)
                    {
                        ans.Add(1);
                    }
                    remain = 1;
                }
                else
                {
                    ans.Add(sum);
                    remain = 0;
                }
            }
             var a = AddListNode(ans);
            return AddListNode(ans);
        }
        public List<int> sum(ListNode l1)
        {
            var list = new List<int>();
            while (true)
            {
                list.Add(l1.val);
                if (l1.next == null)
                {
                    break;
                }
                l1 = l1.next;
            }
            return list;
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
