using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LeetCodeTest
{
    [TestFixture]
    public class IEnumerableTests
    {
        public class CallerItem
        {
            public int IndexId;
            public string PhoneNumber;
            public bool ToInd;
            public bool Show;
        }


        [Test]
        public void test2()
        {
            
            var toCallers = new List<CallerItem>()
            {
                new CallerItem
                {
                    Show = false
                }
            }.Where(x => true);
            if (toCallers.Any())
            {
                toCallers.First().Show = true;
                Console.WriteLine(toCallers.First().Show);
                ; //THIS LOGS 'false'. HOWEVER, IT SHOULD LOG 'true'
            }
        }
        [Test]
        public void list_with_enumerator_implementation()
        {
            var list = new List<TestEnumerable>()
            {
                new TestEnumerable
                {
                    EnumerableInt = new List<int>()
                    {
                        1, 2
                    }.Where(x => true).ToList(),

                    EnumerableString = new List<string>()
                    {
                        "1", "2"
                    }.Where(x => true).ToList(),

                    EnumerableClass = new List<Test>
                    {
                        new Test()
                        {
                            IsAchieved = false
                        }
                    }.Where(x => true)
                },
            };

            foreach (var element in list)
            {
                var firstString = element.EnumerableString.First();
                firstString = "999";

                var firstInt = element.EnumerableInt.First();
                firstInt = 999;

                var firstTest = element.EnumerableClass.First();
                firstTest.IsAchieved = true;
                Console.WriteLine(element.EnumerableClass.First().IsAchieved);

            }

            var ints = new List<int>() { 0 };
            var first = ints.First();
            first = 123;

            var s = list.First().EnumerableString.First();
            var test = list.First().EnumerableClass.First();
            test.IsAchieved.Should().Be(true);
            // s.Should().Be("999");
            // s.Should().BeEquivalentTo("999");
        }

    }

    
    public class TestEnumerable
    {
        public List<string> EnumerableString { get; set; }
        public IEnumerable<Test> EnumerableClass { get; set; }
        public List<int> EnumerableInt { get; set; }
        public string S { get; set; }
    }

    public class Test
    {
        public bool IsAchieved { get; set; } 
    }

    public class TestService
    {
        public void Test2()
        {
            var a = 1;
            List<int> enumerable = new List<int> { 1, 2, 3 };

            //This foreach loop does not compile:
            foreach (var item in enumerable)
            {
                // item = 1; //"cannot assign to item because it is a foreach iteration variable"
            }
        }

        public IEnumerable<TestObject> Test()
        {
            var testObjects = Enumerable.Range(1, 10).Select(i => new TestObject()
            {
                Id = i
            });

            var objects = testObjects.ToList();
            Set(objects);
            var s = "test1";
            return objects;
        }

        private void Set2(string s)
        {
            s = "HAHA";
        }

        private static void Set(IEnumerable<TestObject> testObjects)
        {
            foreach (var testObject in testObjects)
            {
                testObject.Id = 1;
            }
        }
    }

    public class TestObject
    {
        public int Id { get; set; }
    }
}