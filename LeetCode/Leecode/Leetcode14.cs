using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Leecode
{
    class Leetcode14
    {
        public string LongestCommonPrefix(string[] strs)
        {
            var ans = "";
            if (strs.Length == 0)
                return ans;

            var s = strs.OrderBy(x => x.Length).ToList();
            for (int i = 0; i < s[0].Length; i++)
            {
                var check = true;
                foreach (var t in s)
                {
                    if (s[0][i] != t[i])
                    {
                        check = false;
                    }
                }

                if (check)
                {
                    ans += s[0][i];
                }
                else
                {
                    break;
                }
            }

            return ans;

        }
    }
}
