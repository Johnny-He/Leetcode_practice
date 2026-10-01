using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode1431Tests
{
    [Test]
    public void KidsWithCandies()
    {
        var kidsWithCandies = LeetCode1431.KidsWithCandies([2, 3, 5, 1, 3], 3);
        kidsWithCandies.Should().BeEquivalentTo(new List<bool>()
        {
            true,
            true,
            true,
            false,
            true
        });
    }
}

public class LeetCode1431
{
    public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var output = new List<bool>();
        var max = candies.Max();
        var value = max - extraCandies;
        for (var i = 0; i < candies.Length; i++)
        {
            if (candies[i] >= value)
            {
                output.Add(true);
            }
            else
            {
                output.Add(false);
            }
            // var candyWithExtra = candies[i] + extraCandies;
            // if (candyWithExtra >= max)
            // {
            //     output.Add(true);
            // }
            // else
            // {
            //     output.Add(false);
            // }
        }

        return output;
    }
}