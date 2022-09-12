using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Leetcode_medium_
{
    class Leetcode6
    {
        public string Convert(string s, int numRows)
        {
          
            var array = new int[s.Length];
            var chararray = s.ToCharArray();
            for (int i = 0, j = 0, index = 1; i < s.Length; i++)
            {
                array[i] = j;
                if (j == 0)
                {
                    index = 1;
                }
                else if (j == numRows - 1)
                {
                    index = -1;
                }

                j = j + index;
            }

            var temp2 = '0';
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        temp2 = chararray[j + 1];
                        chararray[j + 1] = chararray[j];
                        chararray[j] = temp2;

                    }
                }
            }
            return new string(chararray);
        }
    }
}
