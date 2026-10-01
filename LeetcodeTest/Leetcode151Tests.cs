using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode151Tests
{
    [Test]
    public void ReverseWords()
    {
        var leetCode151 = new LeetCode151();
        var reverseWords = leetCode151.ReverseWords("  hello world  ");
        reverseWords.Should().BeEquivalentTo("world hello");
    }
}

public class LeetCode151
{
    public string ReverseWords(string s)
    {
        var strings = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return string.Join(' ',strings.Reverse());
    }
}
