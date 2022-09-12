using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class KataStringAverageTests
    {
        [TestCase("zero nine five two", "four")]
        [TestCase("one two three four five", "three")]
        [TestCase("four six two three", "three")]
        [TestCase("five four", "four")]
        [TestCase("five, three, six, wdwlmx, one, eight, zero, five, zero", "n/a")]
        public void METHOD(string input, string expected)
        {
            Console.WriteLine();
            var averageString = new StringAverage().AverageString(input);
            averageString.Should().Be(expected);
        }


        [TestCase("seven, five, five, one, nine123seven five five one nine", "n/a")]
        public void test1(string input, string expected)
        {
            var averageString = new StringAverage().AverageString(input);
            Assert.AreEqual(averageString, expected);
        }

        [Test]
        public void test()
        {
            var customers = new List<Customer>();
            var customer = customers.Find(x => x.custId == 1);
            Console.WriteLine(customer.custId);
            Assert.AreEqual(1,1);
        }

    }

    public class StringAverage
    {
       
        private readonly Dictionary<string, int> EnglishIntegerLookup = new Dictionary<string, int>()
        {
            {"zero",0 },
            {"one",1 },
            {"two",2 },
            {"three",3 },
            {"four",4 },
            {"five",5 },
            {"six",6 },
            {"seven",7 },
            {"eight",8 },
            {"nine",9 }
        };
        public string AverageString(string str)
        {
            try
            {
                var average = str.Split(' ')
                    .Select(s => EnglishIntegerLookup[s])
                    .Average();
                var floorAverage = (int)Math.Floor(average);

                return EnglishIntegerLookup.First(x => x.Value == floorAverage).Key;
            }
            catch (Exception)
            {
                return "n/a";
            }
        }



        //private readonly Dictionary<int, string> IntegerArrayInEnglishName = new Dictionary<int, string>()
        //{
        //    {0,"zero" },
        //    {1,"one" },
        //    {2,"two" },
        //    {3,"three" },
        //    {4,"four" },
        //    {5,"five" },
        //    {6,"six" },
        //    {7,"seven" },
        //    {8,"eight" },
        //    {9,"nine" }
        //};

        //private int MappingToInteger(string s)
        //{
        //    return IntegerArrayInEnglishName.First(x => x.Value == s).Key;
        //}
    }

    public class Customer
    {
        public int custId { get; set; }
    }
}