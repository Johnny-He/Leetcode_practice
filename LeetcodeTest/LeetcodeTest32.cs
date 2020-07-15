using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetcodeTest32
    {

        [Test]
        public void longest_valid_parentheses()
        {
            var leetcode = new Leetcode31();
            var input = ")(((((()())()()))()(()))(";
            var input2 = "()";
            //var longestValidParentheses = leetcode.GetLongestValidParentheses(input);
            var mapping = new int[input2.Length];
            var longestValidParentheses = leetcode.GetLongestValidParentheses2(input);
            Assert.AreEqual(22, longestValidParentheses);
        }

    }

    public class Leetcode31
    {
        public int GetLongestValidParentheses(string s)
        {
            var chars = s.ToList();
            var answer = 0;
            for (int i = 0; i < chars.Count - 1; i++)
            {
                if (chars[i] == '(' && chars[i + 1] == ')')
                {
                    var tempChars = new List<char>();
                    tempChars.AddRange(chars);
                    var maxValidateOtherParentheses = 2 + GetMaxValidateOtherParentheses(tempChars, i);
                    answer = answer > maxValidateOtherParentheses ? answer : maxValidateOtherParentheses;
                    Console.WriteLine("==================================");
                }

            }

            return answer;

        }

        private int GetMaxValidateOtherParentheses(List<char> chars, int index)
        {
            var tempChars = new List<char>();
            tempChars.AddRange(chars);

            Console.WriteLine(new string(chars.ToArray()) + $"   index = {index}");
            tempChars.RemoveAt(index);
            tempChars.RemoveAt(index);
            if (tempChars.Count == 0)
            {
                return 0;
            }


            if (tempChars.ElementAtOrDefault(index + 1) != '\0' && tempChars[index] == '(' && tempChars[index + 1] == ')')
            {
                return 2 + GetMaxValidateOtherParentheses(tempChars, index);
            }
            else if (tempChars.ElementAtOrDefault(index - 1) != '\0' && tempChars.ElementAtOrDefault(index) != '\0' && tempChars[index - 1] == '(' && tempChars[index] == ')')
            {
                return 2 + GetMaxValidateOtherParentheses(tempChars, index - 1);
            }

            else if (tempChars.ElementAtOrDefault(index + 1) != '\0' && tempChars.ElementAtOrDefault(index) != '\0' && tempChars[index] == '(' && tempChars[index + 1] == ')')
            {
                return 2 + GetMaxValidateOtherParentheses(tempChars, index);
            }
            else if (tempChars.ElementAtOrDefault(index - 2) != '\0' && tempChars.ElementAtOrDefault(index - 1) != '\0' && tempChars[index - 2] == '(' && tempChars[index - 1] == ')')
            {
                return 2 + GetMaxValidateOtherParentheses(tempChars, index - 2);
            }


            return 0;
        }
        public int GetLongestValidParentheses2(string input)
        {
            var upInputObject = SetUpInputObject(input);

            var answer = 0;
            var maxIndex = 0;
            var minIndex = 0;
            var validCount = 0;
            for (int i = 0; i < upInputObject.Length - 1; i++)
            {
                var preMinIndex = minIndex;
                var preValidCount = validCount;
                var inputObjects = upInputObject;

                if (upInputObject[i].Character == '(' && upInputObject[i + 1].Character == ')')
                {
                    var maxValidateOtherParentheses2 = GetMaxValidateOtherParentheses2(inputObjects, i);
                    maxIndex = maxValidateOtherParentheses2.Where(x => x.IsValid).Max(x => x.Index);
                    minIndex = maxValidateOtherParentheses2.Where(x => x.IsValid).Min(x => x.Index);
                    validCount = maxValidateOtherParentheses2.Count(x => x.IsValid);
                    if (maxIndex < preMinIndex && preMinIndex - maxIndex == 1)
                    {
                        var total = validCount + preValidCount;
                        answer = answer > total ? answer : total;
                    }
                    else
                    {
                        answer = answer > validCount ? answer : validCount;
                    }
                }
            }

            return answer;
        }

        private InputObject[] GetMaxValidateOtherParentheses2(ImmutableArray<InputObject> inputObjects, int index)
        {
            inputObjects[index].IsValid = true;
            inputObjects[index].IsValid = true;
            inputObjects.RemoveAt(index);
            inputObjects.RemoveAt(index+1);

            if (inputObjects.Length == 0)
            {
                return null;
            }

            if (inputObjects.ElementAtOrDefault(index + 1) != null && inputObjects[index].Character == '(' && inputObjects[index + 1].Character == ')')
            {
                return GetMaxValidateOtherParentheses2(inputObjects, index);
            }
            else if (inputObjects.ElementAtOrDefault(index - 1) != null && inputObjects.ElementAtOrDefault(index) != null && inputObjects[index - 1].Character == '(' && inputObjects[index].Character == ')')
            {
                return GetMaxValidateOtherParentheses2(inputObjects, index - 1);
            }

            else if (inputObjects.ElementAtOrDefault(index + 1) != null && inputObjects.ElementAtOrDefault(index) != null && inputObjects[index].Character == '(' && inputObjects[index + 1].Character == ')')
            {
                return GetMaxValidateOtherParentheses2(inputObjects, index);
            }
            else if (inputObjects.ElementAtOrDefault(index - 2) != null && inputObjects.ElementAtOrDefault(index - 1) != null && inputObjects[index - 2].Character == '(' && inputObjects[index - 1].Character == ')')
            {
                return GetMaxValidateOtherParentheses2(inputObjects, index - 2);
            }
            return null;
        }

        private List<InputObject> SetUpInputObjectList(string input)
        {
            return SetUpInputObject(input).ToList();
        }
        private ImmutableArray<InputObject> SetUpInputObject(string input)
        {
            var inputObjects = new InputObject[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputObjects[i] = new InputObject
                {
                    Index = i,
                    Character = input[i],
                    IsValid = false
                };
            }

            return ImmutableArray.Create(inputObjects);
        }
    }

    public class InputObject
    {
        public int Index { get; set; }
        public char Character { get; set; }
        public bool IsValid { get; set; }
    }
}