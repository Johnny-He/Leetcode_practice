using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode345Tests
{
    [Test]
    public void ReverseVowels()
    {
        var actual = LeetCode345.ReverseVowels2("IceCreAm");

        actual.Should().BeEquivalentTo("AceCreIm");
    }
}

public class LeetCode345
{
    public static string ReverseVowels2(string s)
    {
        var vowelsList = new List<char>()
        {
            'a', 'e', 'i', 'o', 'u',
            'A', 'E', 'I', 'O', 'U'
        };
        var input = s.ToList();

        var i = 0;
        var j = s.Length - 1;
        while (i < j)
        {
            if (vowelsList.Contains(input[i]) && vowelsList.Contains(input[j]))
            {
                (input[i], input[j]) = (input[j], input[i]);
                i++;
                j--;
            }
            else if (vowelsList.Contains(input[i]))
            {
                j--;
            }
            else if (vowelsList.Contains(input[j]))
            {
                i++;
            }
            else
            {
                i++;
                j--;
            }
        }

        return new string(input.ToArray());
    }

    public string ReverseVowels(string s)
    {
        var vowelsList = new List<char>()
        {
            'a', 'e', 'i', 'o', 'u',
            'A', 'E', 'I', 'O', 'U'
        };
        var tempList = new List<char>();
        for (var i = 0; i < s.Length; i++)
        {
            if (vowelsList.Contains(s[i]))
            {
                tempList.Add(s[i]);
            }
        }

        var builder = new StringBuilder();
        for (int i = 0, j = tempList.Count - 1; i < s.Length; i++)
        {
            if (vowelsList.Contains(s[i]))
            {
                builder.Append(tempList[j]);
                j--;
            }
            else
            {
                builder.Append(s[i]);
            }
        }

        return builder.ToString();
    }
}