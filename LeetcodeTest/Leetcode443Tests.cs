using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode443Test
{
    [Test]
    public void Test()
    {
        var leetCode443 = new LeetCode443();
        char[] chars = ['a', 'a', 'b', 'b', 'c', 'c', 'c'];
        // char[] chars = ['a', 'b', 'c'];
        var output = leetCode443.Compress(chars);
        // chars.Should().BeEquivalentTo(['a','b','c']);
        chars.Should().BeEquivalentTo(['a', '2', 'b', '2', 'c', '3']);
        output.Should().Be(3);
    }
}

public class LeetCode443
{
    public int Compress(char[] chars)
    {
        if (chars.Length == 1)
        {
            return 1;
        }

        var consecutiveCount = 1;
        var write = 0;
        for (var i = 1; i < chars.Length; i++)
        {
            var previous = chars[i - 1];
            var current = chars[i];

            if (current != previous)
            {
                chars[write] = previous;
                write++;
                if (consecutiveCount != 1)
                {
                    var s = consecutiveCount.ToString();
                    for (var j = 0; j < s.Length; j++)
                    {
                        chars[write + j] = s[j];
                    }

                    write += s.Length;
                }

                consecutiveCount = 1;
            }
            else
            {
                consecutiveCount++;
            }

            if (i == chars.Length - 1)
            {
                chars[write] = current;
                if (consecutiveCount != 1)
                {
                    write++;
                    var s = consecutiveCount.ToString();
                    for (var j = 0; j < s.Length; j++)
                    {
                        chars[write + j] = s[j];
                    }

                    write += s.Length - 1;
                }
            }
        }


        return write + 1;
    }
}