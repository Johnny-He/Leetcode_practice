using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode141Test
    {
        [Test]
        public void test()
        {
            var listNode = new ListNode()
            {
                val = 123
            };
            var temp = listNode;
            var temp2 = listNode;

            temp2.val = 999;
            var listNodeB = new ListNode();
            Console.WriteLine(JsonConvert.SerializeObject(temp));
            Console.WriteLine(JsonConvert.SerializeObject(temp2));
            // var @equals = listNode.Equals(listNode);
            // @equals.Should().Be(true);
            //[5,3,6,2,4,null,null,1]
        }
    }

    public class LeetCode141
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }
            var listNodesRecord = new HashSet<ListNode>();
            while (head.next != null)
            {
                if (listNodesRecord.Contains(head))
                {
                    return true;
                }
                listNodesRecord.Add(head);
                head = head.next;
            }

            return false;
        }
        public bool HasCycle2(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            var listNodeRunWithOneStep = head;
            var listNodeRunWithTwoStep = head;
            while (listNodeRunWithOneStep.next != null && listNodeRunWithTwoStep.next != null && listNodeRunWithTwoStep.next.next != null)
            {

                listNodeRunWithOneStep = listNodeRunWithOneStep.next;
                listNodeRunWithTwoStep = listNodeRunWithTwoStep.next.next;
                if (listNodeRunWithOneStep.Equals(listNodeRunWithTwoStep))
                {
                    return true;
                }
            }

            return false;
        }
    }
}