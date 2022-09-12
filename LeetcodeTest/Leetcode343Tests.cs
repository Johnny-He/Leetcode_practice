using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode343Test
    {
        [Test]
        public void test()
        {
            var solution2 = new Solution2();

            var integerBreak = solution2.IntegerBreak(3);
            integerBreak.Should().Be(36);
            //[5,3,6,2,4,null,null,1]

        }
    }


    public class Solution2
    {

        public int IntegerBreak(int n)
        {
            if (n<2) return 0;
            if (n==2) return 1;
            if (n==3) return 2;
            int p = 1;
            while (n>4) {
                p *= 3;
                n -= 3;
            }
            p *= n;
            return p;
        }
    }
}