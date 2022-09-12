using System.Linq;

namespace Leetcode
{
    class Leetcode5
    {
        public string LongestPalindrome(string s)
        {
          
            for (int k = s.Length; k >= 0; k--)
            {
                s = s.Insert(k, "/");
            }
            var i = 1;
            var max = 0;
            var pos = 0;
            while (i < s.Length)
            {
                var j = 1;
                var temp = 0;

                while (i + j < s.Length && i - j >= 0)
                {
                    if (s[i + j] == s[i - j])
                    {
                        temp++;
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (max < temp)
                {
                    max = max < temp ? temp : max;
                    pos = i;
                }
                i++;
            }

            var ss = s.Substring(pos - max, max * 2 + 1);
            var ans = "";
            for (int j = 0; j < ss.Length; j++)
            {
                if (ss[j] != '/')
                {
                    ans = ans + ss[j];
                }
            }
            return ans;

        }
    }
}
