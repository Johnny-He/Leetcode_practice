using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Leetcode.Leecode
{
    class Leetcode58
    {
        public int LengthOfLastWord(string s)
        {
            if (s == "")
            {
                return 0;
            }
            var a = s.Split(' ');
            if (a.All(x=>x=="") )
            {
                return 0;
            }
            var i = a.Length-1;
            while (a[i].Length==0)
            {
                i--;
            }
            return a[i].Length;
        }
    }
}
