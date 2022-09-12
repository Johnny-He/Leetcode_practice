using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode284Test
    {
        [Test]
        public void test()
        {
            //[5,3,6,2,4,null,null,1]
        }
    }


    public class PeekingIterator
    {
        private List<int> InputList { get; set; }

        private int Index { get; set; }

        // iterators refers to the first element of the array.
        public PeekingIterator(IEnumerator<int> iterator)
        {
            InputList = InitList(iterator).ToList();
            Index = 0;
            // initialize any member here.
        }

        private static IEnumerable<int> InitList(IEnumerator<int> iterator)
        {
            for (int i = 0;; i++)
            {
                yield return iterator.Current;
                if (iterator.MoveNext() == false)
                {
                    yield break;
                }
            }
        }

        // Returns the next element in the iteration without advancing the iterator.
        public int Peek()
        {
            // Console.WriteLine(JsonConvert.SerializeObject(InputList));
            return InputList[Index];
        }

        // Returns the next element in the iteration and advances the iterator.
        public int Next()
        {
            // Console.WriteLine(JsonConvert.SerializeObject(InputList));
            // Console.WriteLine(Index);
            var input = InputList[Index];
            Index++;
            return input;
        }

        // Returns false if the iterator is refering to the end of the array of true otherwise.
        public bool HasNext()
        {
            Console.WriteLine(Index);

            return InputList.ElementAtOrDefault(Index) != 0;
        }
    }
}