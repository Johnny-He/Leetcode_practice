using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class Leetcode17
    {
        [Test]
        public void LeetcodeTest()
        {
            var test17 = new LeetcodeTest17();
            var digits = "23";
            var letterCombinations = test17.LetterCombinations(digits);
        }
    }

    public class LeetcodeTest17
    {
        private List<string> _answerList = new List<string>();
        private Dictionary<int, string> phoneMapping = new Dictionary<int, string>()
        {
            {2,"abc" },
            {3,"def" },
            {4,"ghi" },
            {5,"jki" },
            {6,"mno" },
            {7,"pqrs" },
            {8,"tuv" },
            {9,"wxyz" }
        };
        public IList<string> LetterCombinations(string digits)
        {

            var j = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                TestMethod(Convert.ToInt32(digits[i] - 48));
            }

            return _answerList;
        }

        private void TestMethod(int firstInt)
        {
            //use answerlist to handle other ,so parameter should be only one 
            var firstString = phoneMapping[firstInt];
            for (int i = 0; i < firstString.Length; i++)
            {

                _answerList.Add(firstString[i].ToString());
            }
        }
    }
}