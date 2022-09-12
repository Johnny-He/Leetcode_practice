using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Leecode
{
    public class Leetcode26
    {
        public int RemoveDuplicates(int[] nums)
        {
             var tt  = nums.GroupBy(x => x).Select(g => g.Key).ToArray();
            for (int i = 0; i < tt.Length; i++)
            {
                nums[i] = tt[i];
            }
            return tt.Length ;
        }

        public int test(int n)
        {
            n = 12;
            return n + 1;
        }
    }
}
