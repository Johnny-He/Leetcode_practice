using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FluentAssertions;
using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode48Test
    {
        [Test]
        public void rotate_90_degrees()
        {
            var input = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };

            var leetCode48 = new LeetCode48();
            LeetCode48.Rotate(input);
            input.Should().BeEquivalentTo(new int[][]
            {
                new int[] { 7, 4, 1 },
                new int[] { 8, 5, 2 },
                new int[] { 9, 6, 3 }
            });
        }

        // [Test]
        // public void METHOD()
        // {
        //     var testClass = new TestClass();
        //     testClass.Count = 5;
        //     testClass.TestClass2 = new TestClass2()
        //     {
        //         Length = 123
        //     };
        //     test1(testClass);
        //     Console.WriteLine($"1. testClass.Count = {testClass.Count}");
        //     Console.WriteLine($"2. testClass.Length = {testClass.TestClass2.Length}");
        // }
        //
        // public void test1(TestClass testClass)
        // {
        //     testClass.Count = 9;
        //     testClass.TestClass2 = new TestClass2()
        //     {
        //         Length = 456
        //     };
        //     Console.WriteLine($"2. testClass.Count = {testClass.Count}");
        //     Console.WriteLine($"2. testClass.Length = {testClass.TestClass2.Length}");
        // }
    }

    public class TestClass2
    {
        public int Length { get; set; }
    }

    public class TestClass
    {
        public int Count { get; set; }
        public TestClass2 TestClass2 { get; set; }
    }

    public class LeetCode48
    {
        public static void Rotate(int[][] matrix)
        {
            var n = matrix.Length;
            var matrix2 = new int[n][];
            for (var i = 0; i < n; i++)
            {
                matrix2[i] = new int[n];
                for (var j = 0; j < n; j++)
                {
                    matrix2[i][j] = matrix[i][j];
                }
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    matrix[j][n - 1 - i] = matrix2[i][j];
                }
            }
        }

        private static void Print(int[][] output, int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(output[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}