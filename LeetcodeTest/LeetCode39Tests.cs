using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode39Tests
    {
        [TestCase(new[] { 2, 3, 6, 7 }, 7)]

        public void CombinationSumTest(int[] candidate, int target)
        {
            var leetCode39 = new LeetCode39();
            var combinationSum = leetCode39.CombinationSum(candidate, target);

            combinationSum.Should().BeEquivalentTo(new List<List<int>>()
            {
                new List<int>()
                {
                    2, 2, 3
                }
            });
        }
    }

    public class LeetCode39
    {
        private List<int> TempAnswerList = new List<int>();
        public IList<IList<int>> CombinationSum(int[] candidate, int target)
        {

            var list = candidate.ToList();
            list.Sort();

            //var function = Function(list, target, string.Empty);
            //var function = CombinationSum2(list, target, string.Empty);
            //if (function != string.Empty)
            //{
            //}


            return null;
        }

        private List<int> CombinationSum2(List<int> list, in int target, string empty)
        {
            throw new NotImplementedException();
        }

        //target = 8, list = 2,3,6,7
        public string Function(List<int> list, int target, string currentString)
        {
            var maxNumberBelowTarGet = GetMaxNumberBelowTarget(list, target);
            var remainTargetNumber = target - maxNumberBelowTarGet;
            if (remainTargetNumber == 0)
            {
                var tempRemainTargetNumber = currentString + remainTargetNumber;

                TempAnswerList.AddRange(tempRemainTargetNumber.Split(':').Select(x=>Convert.ToInt32(x)));
                var remainsList = list.Where(x=> target < x).ToList();
                Function(remainsList, remainTargetNumber, currentString);
            }

            if (remainTargetNumber > 0)
            {
                return Function(list, remainTargetNumber, currentString+":" + target.ToString());
            }

            return string.Empty;
        }

        private static int GetMaxNumberBelowTarget(List<int> list, int target)
        {
            return list.Where(x => x <= target).ToList().FirstOrDefault();
        }
    }
}