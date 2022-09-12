using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode24Test
    {
        [Test]
        public void swap_pairs_test()
        {
            var leetCode24 = new LeetCode24();
            var generate5ListNode = new ListNodeHelper().Generate5ListNode();
            var swapPairs = leetCode24.SwapPairs(generate5ListNode);
        }
    }

    public class LeetCode24
    {
        public ListNode SwapPairs(ListNode listNode)
        {
            throw new System.NotImplementedException();
        }
    }
}