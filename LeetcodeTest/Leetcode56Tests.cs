using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode56Test
    {
        [Test]
        public void test()
        {
            var leetCode56 = new LeetCode56();

            var input = new[]
            {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            var input2 = new[]
            {
                new int[] { 2, 3 },
                new int[] { 4, 5 },
                new int[] { 6, 7 },
                new int[] { 1, 10 },
            };
            var input3 = new[]
            {
                new int[] { 1, 4 },
                new int[] { 1, 4 },
            };
            var input4 = new[]
            {
                new int[] { 2, 3 },
                new int[] { 5, 5 },
                new int[] { 2, 2 },
                new int[] { 3, 4 },
                new int[] { 3, 4 },
            };

            var nthUglyNumber = leetCode56.Merge(input4);
            object[] output =
            {
                new int[] { 1, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 },
            };
            nthUglyNumber.Should().BeEquivalentTo(output);
        }
    }

    public class LeetCode56
    {
        public static IList<Interval> Merge(IList<Interval> intervals)
        {
            var sortedIntervals = new SortedSet<Interval>(intervals, new IntervalComparer());

            for (int i = 0; i < sortedIntervals.Count - 1; i++)
            {
                Interval current = sortedIntervals.ElementAt(i);
                Interval next    = sortedIntervals.ElementAt(i + 1);

                // two intervals are overlapped
                if (next.start - current.end < 1)
                {
                    // set current interval's end, and then remove next interval
                    current.end = Math.Max(current.end, next.end);
                    sortedIntervals.Remove(next); 

                    i--; // go back to old index, continue
                }
            }

            return sortedIntervals.ToList();
        }        
        
        public class Interval
        {
            private int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }

      
        public class IntervalComparer : IComparer<Interval>
        {
            public int Compare(Interval leftHandSide, Interval rightHandSide)
            {
                if (leftHandSide.start == rightHandSide.start)
                {
                    return leftHandSide.end.CompareTo(rightHandSide.end);
                }

                return leftHandSide.start.CompareTo(rightHandSide.start);
            }
        }
        public int[][] Merge(int[][] intervals)
        {
            var tempArrayList = new List<int[]>();
            for (var i = 0; i < intervals.Length; i++)
            {
                tempArrayList = MergeIfOverlap(tempArrayList, intervals[i]);
            }

            return tempArrayList.ToArray();
        }

        private List<int[]> MergeIfOverlap(List<int[]> tempArray, int[] interval)
        {
            var resultList = new List<int[]>();
            if (tempArray.Count == 0)
            {
                tempArray.Add(interval);
                return tempArray;
            }

            tempArray.Add(interval);
            var index = tempArray.Count - 1;
            var flag = false;
            while (true)
            {
                for (int i = index-1; i >= 0; i--)
                {
                    if (IsOverLap(tempArray[index], tempArray[i]))
                    {
                        flag = true;
                        var mergeResult = Merge(tempArray[index], tempArray[i]);
                        tempArray.Remove(tempArray[index]);
                        tempArray.Remove(tempArray[i]);
                        tempArray.Add(mergeResult);
                        index = tempArray.Count - 1;
                    }
                }

                index--;
                if (index < 0)
                {
                    break;
                }
            }

            return tempArray;
        }

        private int[] Merge(int[] temp, int[] interval)
        {
            var min = Math.Min(temp[0], interval[0]);
            var max = Math.Max(temp.Last(), interval.Last());
            return min == max ? new[] { min } : new[] { min, max };
        }

        private bool IsOverLap(int[] firstArray, int[] secondArray)
        {
            var begin = firstArray.First();
            var end = firstArray.Last();

            var inputBegin = secondArray.First();
            var inputEnd = secondArray.Last();
            // if (begin == inputBegin && end == inputEnd)
            // {
            //     return false;
            // }

            return IsBetween(begin, inputBegin, inputEnd)
                   || IsBetween(end, inputBegin, inputEnd)
                   || IsBetween(inputBegin, begin, end)
                   || IsBetween(inputEnd, begin, end);
        }

        private static bool IsBetween(int val, int start, int end)
        {
            return val >= start && val <= end;
        }
    }
}