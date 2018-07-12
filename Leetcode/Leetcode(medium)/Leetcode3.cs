using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Leetcode_medium_
{
   public class Leetcode3
    {
        public int LengthOfLongestSubstring(string s)
        {
            int[] lastInd = new int[256];
            for (int i = 0; i < 256; i++)
                lastInd[i] = -1;
            int start = -1;
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (lastInd[s[i]] > start)
                    start = lastInd[s[i]];
                lastInd[s[i]] = i;
                res = Math.Max(res, i - start);
            }
            return res;
            //if (s == "")
            //{ return 0; }
            //var max = 0;
            //var sub = "";
            //var temp = 0;
            //var i = 0;
            //var index = 0;
            //while(i<s.Length)
            //{ 
            //    if (sub.Contains(s[i]))
            //    {
            //        index = index+sub.IndexOf(s[i]) + 1;
            //        sub = ""+s.Substring(index,i-index+1);
            //        temp = 0;
            //    }
            //    else
            //    {
            //        sub = sub + s[i];
            //        temp = sub.Length;
            //    }
            //    max = temp > max ? temp : max;
            //    i++;
            //}
            //return max;

        }

    }
}
