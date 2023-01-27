using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetcodeTest990
    {
        [Test]
        public void test()
        {
            var list = new List<string>()
            {
                "b==a",
                "a==b"
            };
            var equationsPossible = new LeetCode990().EquationsPossible(list.ToArray());
            equationsPossible.Should().BeTrue();
        }

        [Test]
        public void test2()
        {
            var list = new List<string>()
            {
                "c==c",
                "b==d",
                "x!=z"
            };
            var equationsPossible = new LeetCode990().EquationsPossible(list.ToArray());
            equationsPossible.Should().BeTrue();
        }

        [Test]
        public void test3()
        {
            var list = new List<string>()
            {
                "a==a",
            };
            var equationsPossible = new LeetCode990().EquationsPossible(list.ToArray());
            equationsPossible.Should().BeTrue();
        }

        [Test]
        public void test4()
        {
            var list = new List<string>()
            {
                "a!=a",
            };
            var equationsPossible = new LeetCode990().EquationsPossible(list.ToArray());
            equationsPossible.Should().BeFalse();
        }

        [Test]
        public void test5()
        {
            var list = new List<string>()
            {
                "c==c",
                "f!=a",
                "f==b",
                "b==c",
            };
            var equationsPossible = new LeetCode990().EquationsPossible(list.ToArray());
            equationsPossible.Should().BeTrue();
        }
        [Test]
        public void test6()
        {
            var list = new List<string>()
            {
                "a==b",
                "e==c",
                "b==c",
                "a!=e",
            };
            
            var equationsPossible = new LeetCode990().EquationsPossible(list.ToArray());
            equationsPossible.Should().BeFalse();
        }
    }
    

    public class LeetCode990
    {
        public bool EquationsPossible(string[] equations)
        {
            var uf = Enumerable.Range(0, 27).ToArray();
            var eqs = equations.Where(x => x[1] == '=').Select(x => (x[0]-96, x[3]-96));
            var neqs = equations.Where(x => x[1] == '!').Select(x => (x[0]-96, x[3]-96));

            foreach (var (a, b) in eqs)
            {
                uf[GetRoot(a)] = GetRoot(b);
            }

            foreach (var (a, b) in neqs)
            {
                if (GetRoot(a) == GetRoot(b)) return false;
            }

            return true;
       
            // "a==b",
            // "e==c",
            // "b==c",
            // "a!=e",
            int GetRoot(int i)
            {
                while(uf[i] != i)
                {
                    uf[i] = uf[uf[i]]; //目前的被assign
                    i = uf[i];
                }
		
                return i;
            }            
        }
    }
}