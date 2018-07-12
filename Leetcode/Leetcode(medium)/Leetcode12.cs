using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class Leetcode12
    {
        public string IntToRoman(int num)
        {
            var dic = new Dictionary<int, char>()
            {
                {1,'I'},
                {5,'V'},
                {10,'X'},
                {50,'L'},
                {100,'C'},
                {500,'D'},
                {1000,'M'}
            };
            var k = 0;
            var charArray = num.ToString().ToCharArray();
            List<char> chList = new List<char>();
            for (int i = 0; i < charArray.Length; i++)
            {
                k = 0;
                var value = (int)((charArray[i]-48) * Math.Pow(10, charArray.Length-1-i));
                if (value < 1000)
                {
                    if (value == 900)
                    {
                        chList.Add('C');
                        chList.Add('M');
                    }
                    else if (value == 400)
                    {
                        chList.Add('C');
                        chList.Add('D');

                    }
                    else if (value == 90)
                    {
                        chList.Add('X');
                        chList.Add('C');

                    }
                    else if (value == 40)
                    {
                        chList.Add('X');
                        chList.Add('L');

                    }
                    else if (value == 9)
                    {
                        chList.Add('I');
                        chList.Add('X');
                    }
                    else if (value == 4)
                    {
                        chList.Add('I');
                        chList.Add('V');
                    }
                    else
                    {
                        for (k = 0; k < dic.Count - 1; k++)
                        {
                            if (value > dic.ElementAt(k).Key && value < dic.ElementAt(k + 1).Key)
                            {
                                break;
                            }
                        }

                        while (k>=0)
                        {
                            if (value >= dic.ElementAt(k).Key)
                            {
                                value = value - dic.ElementAt(k).Key;
                                chList.Add(dic.ElementAt(k).Value);
                            }
                            else
                            {
                                if (value == 0)
                                {
                                    break;
                                }
                                k--;
                            }
                            if (value == 0)
                            {
                                break;
                            }
                        }
                    }

                }
                else
                {
                    for (int j = 0; j < value / 1000; j++)
                    {
                        chList.Add('M');
                    }
                }
            }
            return new string(chList.ToArray());
        }
    }
}
