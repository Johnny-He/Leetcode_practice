using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode70Test
    {
        [TestCase(1, 1)]
        [TestCase(1, 1)]
        public void test(int input, int output)
        {
            var leetCode70 = new LeetCode70();


            var result = leetCode70.ClimbStairs(1);

            result.Should().Be(output);
        }
    }

    public class LeetCode70
    {
        public int ClimbStairs(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            ClimbStairs(n - 1);
        }
    }
}