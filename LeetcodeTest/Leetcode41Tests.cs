using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using static System.Guid;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode41Test
    {
        [Test]
        public void test()
        {
            var leetCode41 = new LeetCode41();
            var input = new int[] { 3, 4, -1, 1 };
            var firstMissingPositive = leetCode41.FirstMissingPositive(input);


            firstMissingPositive.Should().Be(2);
        }
    }

    public class LeetCode41
    {
        private readonly HashSet<int> inputHashSet = new HashSet<int>();
        public int FirstMissingPositive(int[] nums)
        {
            foreach (var i in nums)
            {
                inputHashSet.Add(i);
            }

            for (var i = 1; i < int.MaxValue; i++)
            {
                if (!inputHashSet.Contains(i))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}