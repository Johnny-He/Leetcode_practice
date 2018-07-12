using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Leetcode.Leecode
{
    public class Leetcode13
    {
        public int RomanToInt(string s)
        {
            var dic = new Dictionary<string, int>()
            {
                {"I",1},
                {"V", 5},
                {"X", 10},
                {"L", 50},
                {"C", 100},
                {"D", 500},
                {"M", 1000}
            };
            var index = 0;
            var sum = 0;
        
            while(index<s.Length)
            { 
                if (index+1<s.Length&&dic[s[index].ToString()] < dic[s[index + 1].ToString()])
                {
                    sum += dic[s[index+1].ToString()]-dic[s[index].ToString()];
                    index++;
                }
                else
                {
                    sum += dic[s[index].ToString()];
                }
                index++;
            }
            return sum;
        }
    }
}
