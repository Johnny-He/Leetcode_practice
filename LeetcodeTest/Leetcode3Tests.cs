using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode3Test
    {
        [Test]
        public void test()
        {
            var leetCode3 = new LeetCode3();
            var output = LeetCode3.LengthOfLongestSubstring("bbbbb");
            output.Should().Be(1);
        }
    }


    public class LeetCode3
    {
        
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 1)
            {
                return 1;
            }

            var maxLength = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var temp = s[i].ToString();
                for (var j = i + 1; j < s.Length; j++)
                {
                    if (temp.Contains(s[j]))
                    {
                        maxLength = Math.Max(maxLength, j - i);
                        break;
                    }

                    if (j == s.Length - 1)
                    {
                        maxLength = Math.Max(maxLength, j - i + 1);
                    }
                    temp += s[j];
                }
            }
            return maxLength;
        }

        // public static int LengthOfLongestSubstring(string s)
        // {
        //     var maxLength = 0;
        //     for (int i = 0; i < s.Length; i++)
        //     {
        //            
        //     }
        //     
        // }
    }
}