using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetcodeTest946
    {
        [Test]
        public void METHOD()
        {
            var leetCode946 = new LeetCode946();
            var a = leetCode946.ValidateStackSequences(
                new int[5] { 1, 2, 3, 4, 5 },
                new int[5] { 4, 3, 5, 1, 2 });
            a.Should().BeFalse();
        }
        [Test]
        public void METHOD2()
        {
            //pushed = [1,2,3,4,5], popped = [4,3,5,1,2]


            var leetCode946 = new LeetCode946();
            var a = leetCode946.ValidateStackSequences(
                new int[5] { 4, 0, 1, 2, 3 },
                new int[5] { 4, 2, 3, 0, 1 });
            a.Should().BeFalse();
        }
       
    }

    public class LeetCode946
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            var stack = new Stack<int>();
            stack.Push(pushed[0]);
            var j = 0;
            var i= 1;
            while (j < popped.Length)
            {
                //need pop or not
                //push
                if (stack.Count !=0 && stack.Peek() == popped[j])
                {
                    stack.Pop();
                    j++;
                }
                else
                {
                    if (i >= pushed.Length)
                    {
                        return false;
                    }
                    stack.Push(pushed[i]);
                    i++;
                }
            }

            return true;
        }

        public bool ValidateStackSequences2(int[] pushed, int[] popped)
        {
            var stack = new List<int>()
            {
                pushed[0]
            };
            var stackIndex = 0;
            var j = 0;
            var i = 1;
            while (j < popped.Length)
            {
                //need pop or not
                //push
                if (stackIndex != -1 && stack[stackIndex] == popped[j])
                {
                    stack.Remove(stack[stackIndex]);
                    stackIndex--;
                    j++;
                }
                else
                {
                    if (i >= pushed.Length)
                    {
                        return false;
                    }
                    stack.Add(pushed[i]);
                    i++;
                    stackIndex++;
                }

               
            }

            return true;
        }
    }
}