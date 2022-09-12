using System;
using FluentAssertions;
using NSubstitute.Exceptions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode45Test
    {
        [Test]
        public void test()
        {
            var leetCode45 = new LeetCode45();
            // var input = new int[] { 2, 3, 1, 1, 4 };
            // var input = new int[] { 1,2,3 };
            // var input = new int[] { 1,2,1,1,1 };
            // var input = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 0 };
            var input = new int[] { 2, 3, 0,1 };
            var firstMissingPositive = leetCode45.Jump(input);


            firstMissingPositive.Should().Be(2);
        }
    }

    public class LeetCode45
    {

        public int Jump(int[] nums)
        {
            var count = 0;
            var current = 0;
            var finalIndex = nums.Length - 1;
            var i = 0;
            while (current < finalIndex)
            {
                count++;
                var previous = current;
                for ( ;i <= previous; i++)
                {
                    current = Math.Max(nums[i] + i, current);
                }
            }

            return count;
        }

    }
}