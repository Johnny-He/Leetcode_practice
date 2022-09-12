using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode1679Test
    {
        [Test]
        public void test()
        {
            var solution2 = new LeetCode1679();
            // var integerBreak = solution2.MaxOperations2(new[] { 3, 1, 5, 1, 1, 1, 1, 1, 2, 2, 3, 2, 2 }, 1);
            var integerBreak = solution2.MaxOperations2(new[] { 3, 1, 3, 4, 3 }, 6);
            integerBreak.Should().Be(1);
            //[5,3,6,2,4,null,null,1]
        }
    }


    public class LeetCode1679
    {
        public int MaxOperations(int[] nums, int k)
        {
            var count = 0;
            var inputList = nums.ToList();
            while (inputList.Count > 0)
            {
                var firstNumber = inputList.First();
                var anotherPairNumber = k - firstNumber;
                inputList.Remove(firstNumber);

                if (!inputList.Exists(x => x == anotherPairNumber)) continue;
                inputList.Remove(anotherPairNumber);
                count++;
            }

            return count;
        }

        public int MaxOperations2(int[] nums, int k)
        {
            Array.Sort(nums);
            var left = 0;
            var right = nums.Length - 1;
            var result = 0;
            while (left < right)
            {
                if (nums[left] + nums[right] > k)
                {
                    right--;
                }
                else if (nums[left] + nums[right] < k)
                {
                    left++;
                }
                else if(nums[left] + nums[right] == k)
                {
                    result++;
                    left++;
                    right--;
                }
            }

            return result;
        }
    }
}