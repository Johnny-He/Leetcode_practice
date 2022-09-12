using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Leecode
{
    class Leetcode66
    {
        public int[] PlusOne(int[] digits)
        {
            var test = digits.ToList();
            var i = test.Count-1;
            while (i>=0)
            {
                test[i]++;
                if (i == 0&&test[i]==10)
                {
                    test[i] = 0;
                    test.Insert(0,1);
                    break;
                }
                if (test[i] == 10)
                {
                    test[i] = 0;
                    i--;
                }
                else
                {
                    break;
                }
            }

            return test.ToArray();
        }
    }
}
