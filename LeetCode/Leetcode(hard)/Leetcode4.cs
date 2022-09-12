using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    class Leetcode4
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var all = new int[nums1.Length + nums2.Length];
            nums1.CopyTo(all, 0);
            nums2.CopyTo(all, nums1.Length);
            double ans = 0;
            Array.Sort(all);
            if (all.Length % 2 == 0)
            {
                ans = Convert.ToDouble(all[all.Length / 2] + all[all.Length / 2-1] ) / 2;
            }
            else if (all.Length % 2 == 1)
            {
                ans = Convert.ToDouble(all[all.Length / 2]);
            }

            return ans;
        }
    }
}
