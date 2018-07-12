using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class Leetcode15
    {
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            var ans = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                for (int start = i + 1, end = nums.Length - 1; start < end;)
                {
                    if (nums[start] == nums[start - 1])
                    {
                        start++;
                        continue;
                    }

                    if (nums[i] + nums[start] + nums[end] == 0)
                    {
                        ans.Add(new List<int>() { nums[i], nums[start], nums[end] });
                        start++;
                    }

                    if (nums[i] + nums[start] + nums[end] < 0)
                    {
                        start++;
                    }
                    else if (nums[i] + nums[start] + nums[end] > 0)
                    {
                        end--;
                    }
                }
            }

            return ans;
        }
    }
}