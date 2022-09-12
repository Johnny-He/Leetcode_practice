using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode264Test
    {
        [Test]
        public void test()
        {
            var leetCode264 = new LeetCode264();

            var nthUglyNumber = leetCode264.NthUglyNumber(137);
            nthUglyNumber.Should().Be(4096);
        }
    }

    public class LeetCode264
    {
        public int NthUglyNumber(int n)
        {
            var uglyList = new List<int>(){1};
            var i2 = 0;
            var i3 = 0;
            var i5 = 0;
            while (uglyList.Count() < n)
            {
                var m2 = uglyList[i2] * 2;
                var m3 = uglyList[i3] * 3;
                var m5 = uglyList[i5] * 5;
                var mn = Math.Min(m2, Math.Min(m3, m5));
                if (mn == m2)
                {
                    i2++;
                }
                if (mn == m3)
                {
                    i3++;
                }
                if (mn == m5)
                {
                    i5++;
                }

                uglyList.Add(mn);
            }
            return uglyList[n - 1];
        }
    }
}