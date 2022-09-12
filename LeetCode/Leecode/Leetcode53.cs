using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Leecode
{
   public  class Leetcode53
    {
        public int MaxSubArray(int[] nums)
        {
            var max = 0;
            var temp = 0;
            if (nums.Max() <= 0)
            {
                return nums.Max();
            }
            for (int i = 0; i < nums.Length; i++)
            {
                temp  = temp + nums[i];
                if (temp < 0)
                {
                    temp = 0;
                }
                if (max <= temp)
                {
                    max = temp;
                }
            }
            return max; 
        }
    }
}
