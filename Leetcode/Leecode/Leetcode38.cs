using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Leetcode.Leecode
{
    class Leetcode38
    {
        public string CountAndSay(int n)
        {
            var test = new String[100];
            test[0] = "1";
            for (int i = 1; i < n ; i++)
            {
                test[i] = convert(test[i - 1]);

            }

            return test[n-1];

        }

        private string convert(string s)
        {
            var index = 0;
            var tt = "";
            while (true)
            {
                var n = 0;
                var temp = index;
                if (index == s.Length )
                {
                    break;
                }
                for (int i = index ; i < s.Length; i++)
                {
                    if (s[temp] == s[i])
                    {
                        index++;
                        n++;
                    }
                    else
                    {
                        index = i;
                        break;
                    }
                }
                    tt = tt + n.ToString()+s[index-1];
                
            }

            return tt;
        }
    }
}
