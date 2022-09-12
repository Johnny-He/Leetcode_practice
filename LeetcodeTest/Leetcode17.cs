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
            foreach (var letterCombination in letterCombinations)
            {
                Console.Write($"{letterCombination},");
            }
        }
    }

    public class LeetcodeTest17
    {
        private readonly List<string> _answerList = new List<string>();
        private readonly Dictionary<int, string> _phoneMapping = new Dictionary<int, string>()
        {
            {2,"abc" },
            {3,"def" },
            {4,"ghi" },
            {5,"jkl" },
            {6,"mno" },
            {7,"pqrs" },
            {8,"tuv" },
            {9,"wxyz" }
        };
        public IList<string> LetterCombinations(string digits)
        {
            for (var index = 0; index < digits.Length; index++)
            {
                var phoneNumber = digits[index]-48;
                if (index == 0)
                {
                    InitAnswerList(phoneNumber);
                }
                else
                {
                    LetterCombinations(Convert.ToInt32(phoneNumber));
                }
            }

            return _answerList;
        }

        private void InitAnswerList(int phoneNumber)
        {
            for (int i = 0; i < _phoneMapping[phoneNumber].Length; i++)
            {
                _answerList.Add(_phoneMapping[phoneNumber][i].ToString());
            }
        }

        private void LetterCombinations(int index)
        {
            //use answerlist to handle other ,so parameter should be only one 
            var firstString = _phoneMapping[index];
            var tempList = new List<string>();
            tempList.AddRange(_answerList);
            _answerList.Clear();
            foreach (var t in tempList)
            {
                foreach (var t1 in firstString)
                {
                    _answerList.Add(t + t1);
                }
            }
        }
    }
}