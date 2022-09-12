using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Leetcode.Leecode
{
    public class Leetcode20
    {
        public bool IsValid(string s)
        {
            var dic = new Dictionary<char, char>()
            {
                {'{', '}'},
                {'(', ')'},
                {'[', ']'}
            };
            var list = s.ToList();
            while (true)
            {
                if (list.Count == 0 )
                {
                    return true;
                }
                else if (list.Count % 2 == 1)
                {
                    return false;
                }

                var check = false;
                for (int i = 0; i < list.Count; i++)
                {
                    if (dic.ContainsKey(list[i])&&i+1<list.Count)
                    {
                        if (list[i + 1] == dic[list[i]])
                        {
                            list.RemoveAt(i+1);
                            list.RemoveAt(i);
                            check = true;
                        }
                    }
                }

                if (!check)
                {
                    return check;
                }
               
            }
        }
        
        public int FindNextCorresnspond(char c, string s ,int startpos)
        {
            for (int i = startpos+1; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }
    }

}
