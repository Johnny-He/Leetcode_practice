using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode647Test
    {
        [Test]
        public void test()
        {
            var leetCode647 = new LeetCode647();
            var countSubstrings = new LeetCode647().CountSubstrings("aaa");
            countSubstrings.Should().Be(6);
        }
    }

// aba, abba,bbba
    public class LeetCode647
    {
        public int CountSubstrings(string s)
        {
            var palindromicCount = 0;
            for (var index = 0; index < s.Length; index++)
            {
                palindromicCount += GetSubStringCount(index, index, s);
                palindromicCount += GetSubStringCount(index, index+1, s);
            }

            return palindromicCount;
        }

        private static int GetSubStringCount(int left, int right, string s)
        {
            var count = 0;
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                count++;
                left--;
                right++;
            }

            return count;
        }
    }
}