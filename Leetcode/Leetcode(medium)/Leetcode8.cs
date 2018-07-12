using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class Leetcode8
    {
        public int MyAtoi(string str)
        {
            var max = Convert.ToInt32(Math.Pow(2, 31) - 1);
            var min = Convert.ToInt32(Math.Pow(2, 31) * -1);
            var maxlist = new List<int>();
            var minlist = new List<int>();
            var temp1 = max;
            var temp2 = min;
            while (temp1 > 0)
            {
                maxlist.Add(temp1 % 10);
                temp1 = temp1 / 10;
                minlist.Add(temp2 % 10*-1);
                temp2 = temp2 / 10;
            }
            maxlist.Reverse();
            minlist.Reverse();

            var check = true;
            var plus = true;
            var i = 0;
            if (str == "")
            {
                return 0;
            }

            while (i < str.Length)      //判定空白至不是空白處
            {
                if (str[i] != ' ' && (str[i] < 48 || str[i] > 57) && str[i] != '-' && str[i] != '+')
                {
                    check = false;
                    break;
                }
                else if (str[i] != ' ')
                {
                    break;
                }
                i++;
            }
            var index = 1;                  //第一個為正負號
            if (i >= str.Length || !check)
            {
                return 0;
            }
            if (str[i] == '-')
            {
                plus = false;
                index = -1;
                i++;
            }
            else if (str[i] == '+')
            {
                i++;
            }

            while (i < str.Length)
            {
                if (str[i] != '0')
                {
                    break;
                }
                i++;
            }
            if (i >= str.Length)
            {
                return 0;
            }
            var list = new List<char>();
            while (str[i] >= 48 && str[i] <= 57 && i < str.Length)
            {

                list.Add(str[i]);
                i++;
                if (i >= str.Length)
                {
                    break;
                }
            }

            if (list.Count > 10)
            {
                return plus ? max : min;
            }
            else if (list.Count == 10)
            {
                var j = 0;
                var check2 = true;
                if (plus)
                {
                    while (j < list.Count)
                    {
                        if (list[j] - 48 > maxlist[j])
                        {
                            check2 = false;

                            break;
                        }
                        else if (list[j] - 48 == maxlist[j])
                        {
                            if (j == list.Count - 1)
                            {

                            }
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    while (j < list.Count)
                    {
                        if (list[j] - 48 > minlist[j])
                        {
                            check2 = false;

                            break;
                        }
                        else if (list[j] - 48 == minlist[j])
                        {
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }


                if (!check2)
                {
                    return plus ? max : min;
                }
            }
            var sum = 0;

            i = list.Count - 1;
            while (i >= 0)
            {
                sum = sum + (int)char.GetNumericValue(list[i]) * index;
                index = index * 10;
                i--;
            }
            return sum;
        }
    }
}
