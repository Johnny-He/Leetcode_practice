using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode268Test
    {
        [Test]
        public void test()
        {
            var leetCode268 = new LeetCode268();

            var nthUglyNumber = leetCode268.MissingNumber(new int[]{3,0,1});
            nthUglyNumber.Should().Be(2);
        }
    }

    public class LeetCode268
    {
        public int MissingNumber(int[] nums)
        {
            var orderedEnumerable = nums.OrderBy(x=>x).ToArray();
            var i = 0;
            for (i = 0; i < nums.Length; i++)
            {
                if (orderedEnumerable[i] != i)
                {
                    return i;
                }
            }

            return i;

        }
    }
}