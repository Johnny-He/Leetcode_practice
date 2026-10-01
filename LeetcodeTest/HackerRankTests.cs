using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class HackerRankTests
    {
        [Test]
        public void Test()
        {
            var hackerRank = new HackerRank();
            var removableIndices = hackerRank.GetRemovableIndices2("aabbb", "aabb");
            removableIndices.Should().BeEquivalentTo(new List<int>()
            {
                2, 3, 4
            });
        }

        [Test]
        public void Test2()
        {
            var hackerRank = new HackerRank();
            var removableIndices = hackerRank.GetRemovableIndices2("mmgghh", "mfggh");
            removableIndices.Should().BeEquivalentTo(new List<int>()
            {
                -1
            });
        }

        [Test]
        public void Test3()
        {
            var hackerRank = new HackerRank();
            var removableIndices = hackerRank.GetRemovableIndices2("a", "");
            removableIndices.Should().BeEquivalentTo(new List<int>()
            {
                0
            });
        }

        [Test]
        public void Test4()
        {
            var hackerRank = new HackerRank();
            var removableIndices = hackerRank.GetRemovableIndices2("abc", "de");
            removableIndices.Should().BeEquivalentTo(new List<int>()
            {
                -1
            });
        }

        [Test]
        public void Test5()
        {
            var hackerRank = new HackerRank();
            var removableIndices = hackerRank.GetRemovableIndices2("aa", "b");
            removableIndices.Should().BeEquivalentTo(new List<int>()
            {
                -1
            });
        }
    }

    public class HackerRank
    {
        public List<int> GetRemovableIndices2(string str1, string str2)
        {
            var firstDiffIndexFromLeftToRight = 0;
            while (firstDiffIndexFromLeftToRight < str2.Length &&
                   str1[firstDiffIndexFromLeftToRight] == str2[firstDiffIndexFromLeftToRight])
            {
                firstDiffIndexFromLeftToRight++;
            }

            var i = 0;
            while (i <= str2.Length - 1 &&
                   str1[str1.Length - 1 - i] == str2[str2.Length - 1 - i])
            {
                i++;
            }

            var firstDiffIndexFromRightToLeft = str1.Length - 1 - i;


            var temp = str1[firstDiffIndexFromRightToLeft];
            var outputList = new List<int>();
            if (firstDiffIndexFromRightToLeft > firstDiffIndexFromLeftToRight)
            {
                return [-1];
            }

            for (var k = firstDiffIndexFromRightToLeft; k <= firstDiffIndexFromLeftToRight; k++)
            {
                if (str1[k] == temp)
                {
                    outputList.Add(k);
                }
                else
                {
                    return [-1];
                }
            }


            return outputList;
        }

        public List<int> GetRemovableIndices3(string str1, string str2)
        {
            if (str1.Length != str2.Length + 1)
                return [-1];

            var m = str2.Length;

            var prefix = 0;
            while (prefix < m && str1[prefix] == str2[prefix])
            {
                prefix++;
            }

            var j = 0;
            while (j < m && str1[str1.Length - 1 - j] == str2[m - 1 - j])
            {
                j++;
            }

            var start = str1.Length - 1 - j; // 最小可刪索引
            var end = prefix; // 最大可刪索引

            if (start > end)
                return [-1];

            var result = new List<int>(end - start + 1);
            for (var i = start; i <= end; i++)
                result.Add(i);

            return result;
        }
    }
}