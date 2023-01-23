using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.Core;

namespace LeetCodeTest
{
    public class Solution2
    {

        public int IntegerBreak(int n)
        {
            if (n<2) return 0;
            if (n==2) return 1;
            if (n==3) return 2;
            int p = 1;
            while (n>4) {
                p *= 3;
                n -= 3;
            }
            p *= n;
            return p;
        }
    }
}