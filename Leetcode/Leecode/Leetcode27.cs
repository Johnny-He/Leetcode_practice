using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Leecode
{
    class Leetcode27
    {
        public int RemoveElement(int[] nums, int val)
        {
           /* var array = nums.Where(x => x != val).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                nums[i] = array[i];
            }

            return array.Length;*/
            Array.Sort(nums);
            var i = 0;
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (val != nums[j])
                    {
                        nums[i] = nums[j];
                        i++;
                    }
                }   
            
            return i;
        }
    }
}
