using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode1071Tests
{
    [TestCase("ABCABC", "ABC", "ABC")]
    [TestCase("ABABAB", "ABAB", "AB")]
    [TestCase("LEET", "CODE", "")]
    [TestCase("AAAAAB", "AAA", "")]
    [TestCase("ABCABC", "ABCABCABC", "ABC")]
    [TestCase("TAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXX")]
    public void GcdOfStrings(string str1, string str2, string output)
    {
        var leetcode1071 = new Leetcode1071();
        var gcdOfStrings = leetcode1071.GcdOfStrings(str1, str2);
        gcdOfStrings.Should().BeEquivalentTo(output);
    }
}

public class Leetcode1071
{
    public string GcdOfStrings(string str1, string str2)
    {
        var longStr = str1.Length >= str2.Length ? str1 : str2;
        var shortStr = str1.Length >= str2.Length ? str2 : str1;
        
        var output = string.Empty;
        for (var i = 0; i < shortStr.Length; i++)
        {
            var subStringOfShortStr = shortStr.Substring(0,i+1);
            if (IsGcd(shortStr, subStringOfShortStr) && IsGcd(longStr, subStringOfShortStr))
            {
                output = subStringOfShortStr;
            }
        }

        return output;
    }

    private static bool IsGcd(string str, string subStringOfShortStr)
    {
        if (str == string.Empty)
        {
            return true;
        }
        if (str.Length < subStringOfShortStr.Length)
        {
            return false;
        }
        if (str.Substring(0, subStringOfShortStr.Length) == subStringOfShortStr)
        {
            return IsGcd(str.Substring(subStringOfShortStr.Length), subStringOfShortStr);
        }

        return false;
    }


    public string GcdOfStrings2(string str1, string str2)
    {
        var output = string.Empty;
        for (var i = 0; i < str2.Length; i++)
        {
            var substringOfStr2 = str2.Substring(0, i + 1);
            var str1Copy = str1;
            var canDivide = true;
            while (true)
            {
                if (str1Copy.Length < substringOfStr2.Length)
                {
                    canDivide = false;
                    break;
                }

                var substringOfStr1Copy = str1Copy.Substring(0, i + 1);
                if (substringOfStr1Copy == substringOfStr2)
                {
                    if (str1Copy.Length > substringOfStr2.Length)
                    {
                        // ABABAB
                        // ABAB
                        str1Copy = str1Copy.Substring(i + 1);
                        if (str1Copy.Length < substringOfStr2.Length)
                        {
                            canDivide = false;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    canDivide = false;
                    break;
                }
            }

            if (canDivide)
            {
                output = substringOfStr2;
            }
        }

        return output;
    }
}