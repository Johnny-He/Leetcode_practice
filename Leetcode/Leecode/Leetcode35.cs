using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Leecode
{
    class Leetcode35
    {
        public int SearchInsert(int[] nums, int target)
        {
            var list = nums.ToList();
            list.Add(target);
            list.Sort();
            var index = list.IndexOf(target);

            return index;
        }
    }
}
