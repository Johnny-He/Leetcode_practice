using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode1768Tests
{
    [TestCase("abc", "pqr", "apbqcr")]
    [TestCase("ab", "pqrs", "apbqrs")]
    [TestCase("abcd", "pq", "apbqcd")]
    public void MergeTwoString(string word1, string word2, string output)
    {
        var mergeTwoString = LeetCode1768.MergeTwoString(word1, word2);
        mergeTwoString.Should().BeEquivalentTo(output);
    }
}

public static class LeetCode1768
{
    public static string MergeTwoString(string word1, string word2)
    {
        var output = string.Empty;

        var max = Math.Max(word1.Length, word2.Length);
        for (var i = 0; i < max; i++)
        {
            if (i < word1.Length)
            {
                output += word1[i];
            }

            if (i < word2.Length)
            {
                output += word2[i];
            }
        }

        return output;
    }
}