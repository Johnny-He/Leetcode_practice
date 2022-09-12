using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FluentAssertions;
using LeetCodeTest.Helper;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode49Test
    {
        [TestCase(10, 2, 100)]
        [TestCase(10, -1, 1)]
        [TestCase(2, -2, 0.25)]
        public void Pow(double x, int n, double expected)
        {
            var output = new leetCode50().Pow(x, n);
            output.Should().Be(expected);
        }
    }

    public class leetCode50
    {
        public double Pow(double x, int n)
        {
            var tmp = x;

            if (n > 0)
            {
                for (int i = n; i > 1; i--)
                {
                    x = x * tmp;
                }
            }
            else if (n < 0)
            {
                for (int i = n; i < -1; i++)
                {
                    x = x / tmp;
                }
            }

            return x;
        }
    }
}