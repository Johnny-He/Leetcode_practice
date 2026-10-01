using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode334Test
{
    [Test]
    public void Test()
    {
        var leetCode105 = new LeetCode334();
        var increasingTriplet = leetCode105.IncreasingTriplet([1, 2, 3, 4, 5]);
        increasingTriplet.Should().BeTrue();
    }
}

public class LeetCode334
{
    public bool IncreasingTriplet(int[] nums)
    {
        var firstMin = nums[0];
        var secondMin = int.MaxValue;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] < firstMin)
            {
                firstMin = nums[i];
            }
            else if (nums[i] > firstMin)
            {
                if (nums[i] < secondMin)
                {
                    secondMin = nums[i];
                }
                else if (nums[i] > secondMin)
                {
                    return true;
                }
            }
        }

        return false;
    }
}