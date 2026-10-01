using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode238Test
{
    [Test]
    public void Test()
    {
        var leetCode105 = new LeetCode238();

        var productExceptSelf = leetCode105.ProductExceptSelf([1, 2, 3, 4]);
        productExceptSelf.Should().BeEquivalentTo([24, 12, 8, 6]);
    }
}

public class LeetCode238
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var lastNumber = 1;
        var outputs = new int[nums.Length];
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            outputs[i] = lastNumber * nums[i];
            lastNumber = outputs[i];
        }

        lastNumber = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                outputs[i] = outputs[i + 1];
            }
            else if (i == nums.Length - 1)
            {
                outputs[i] = lastNumber;
            }
            else
            {
                outputs[i] = lastNumber * outputs[i + 1];
            }

            lastNumber *= nums[i];
        }

        return outputs;
    }

    public int[] ProductExceptSelf2(int[] nums)
    {
        var leftProducts = new int[nums.Length];
        var lastNumber = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            leftProducts[i] = lastNumber * nums[i];
            lastNumber = leftProducts[i];
        }

        var rightProduct = new int[nums.Length];
        lastNumber = 1;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            rightProduct[i] = lastNumber * nums[i];
            lastNumber = rightProduct[i];
        }

        var outputs = new int[nums.Length];
        //1,2,3,4
        //24,12,8,6

        //left:  1,2,6,24
        //right: 24,24,12,4
        for (var i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                outputs[i] = rightProduct[i + 1];
            }
            else if (i == nums.Length - 1)
            {
                outputs[i] = leftProducts[i - 1];
            }
            else
            {
                outputs[i] = leftProducts[i - 1] * rightProduct[i + 1];
            }
        }

        return outputs;
    }
}