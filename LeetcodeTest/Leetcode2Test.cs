using System;
using System.Collections.Generic;
using Leetcode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetcodeTest
{
    [TestClass]
    public class Leetcode2Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var leetcode2 = new Leetcode2();
            var l1 = leetcode2.AddListNode(new List<int>() {9, 9, 9, 9, 9, 9, 9, 9, 9, 9});
            var l2 = leetcode2.AddListNode(new List<int>() {9, 9, 9, 9, 9, 9, 9, 9, 9, 9});
            var a = leetcode2.AddTwoNumbers(l1, l2);
            Assert.AreEqual(leetcode2.sum(a), a);
        }
    }
}
