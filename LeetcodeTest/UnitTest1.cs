using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeTest
{
    public class Leetcode1Test
    {
        private Leetcode123 _leetcode1;

        [Test]
        public void two_sum()
        {
            _leetcode1 = new Leetcode123();
            var sum = 9;
            var actual = _leetcode1.TwoSum(new List<int>() { 2, 7, 11, 15 }.ToArray(), sum);
            var expected = new List<int>() { 0, 1 };
            Assert.AreEqual(expected,actual);
            Assert.Pass();
        }
    }

    public class Leetcode123
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var answerList = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        answerList.Add(i);
                        answerList.Add(j);
                        return answerList.ToArray();
                    }
                }
            }

            return answerList.ToArray();
        }
    }
}