using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode5Test
    {
        [Test]
        public void test()
        {
            var leetCode5 = new LeetCode5();
            var longestPalindrome = leetCode5.LongestPalindrome("aaaa");
            longestPalindrome.Should().BeEquivalentTo("aaaa");
        }
    }

    public class LeetCode5
    {
        public string LongestPalindrome(string s)
        {
            var maxPalindrome = string.Empty;
            for (var i = 0; i < s.Length - 1; i++)
            {
                if (i - 1 >= 0 && s[i - 1] == s[i + 1])
                {
                    var palindrome = GetPalindrome(s, i - 1, i + 1);
                    if (palindrome.Length > maxPalindrome.Length)
                    {
                        maxPalindrome = palindrome;
                    }
                }

                if (s[i] == s[i + 1])
                {
                    var palindrome = GetPalindrome(s, i, i + 1);
                    if (palindrome.Length > maxPalindrome.Length)
                    {
                        maxPalindrome = palindrome;
                    }
                }
            }

            return maxPalindrome == string.Empty ? s.Substring(0, 1) : maxPalindrome;
        }

        private static string GetPalindrome(string s, int initLeft, int initRight)
        {
            while (s[initLeft] == s[initRight])
            {
                initLeft--;
                initRight++;

                if (initLeft < 0 || initRight > s.Length - 1 || s[initLeft] != s[initRight])
                {
                    initLeft++;
                    initRight--;
                    break;
                }
            }

            return s.Substring(initLeft, initRight - initLeft + 1);
        }
    }
}