using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using static System.Guid;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode535Test
    {
        [Test]
        public void test()
        {
            var leetCode535 = new LeetCode535();

            var tinyUrl = leetCode535.encode("https://leetcode.com/problems/design-tinyurl");
            var output = leetCode535.decode(tinyUrl);
            output.Should().Be("https://leetcode.com/problems/design-tinyurl");
        }
    }

    public class LeetCode535
    {
        private readonly Dictionary<string, string> TinyUrlLookUp = new Dictionary<string, string>();
        private const string TinyBaseUrl = "https://tinyurl.com";

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            var randomFileName = Path.GetRandomFileName();
            TinyUrlLookUp.TryAdd(randomFileName, longUrl);
            return $"{TinyBaseUrl}/{randomFileName}";
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            var uri = new Uri(shortUrl);
            var tryGetValue = TinyUrlLookUp.TryGetValue(uri.AbsolutePath.Trim('/'),out var value);
            return tryGetValue ? value : null;
        }
    }
}