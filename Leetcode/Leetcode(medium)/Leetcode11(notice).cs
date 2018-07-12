using System;
using System.Collections;
using System.Linq;

namespace Leetcode
{
    public class Leetcode11
    {
        public int MaxArea2(int[] height)
        {
            var i = 0;
            var maxcontainer = 0;
            var last = height.Length - 1;
            while (i < last)
            {
                maxcontainer = Math.Max(maxcontainer, (last - i) * Math.Min(height[i], height[last]));
                if(height[i]>=height[last])
                {
                    last--;
                }
                else if (height[last] > height[i])
                {
                    i++;
                }
            }


            return maxcontainer;
        }
    }


//    for (int j = 0; j<height.Length; j++)
//    {
//    if (height[i] <= height[j])
//    {
//    var dis = j - i;
//        if (dis< 0)
//    {
//        dis = dis* -1;
//    }
//    maxcontainer = maxcontainer<(dis* height[i]) ? (dis* height[i]) : maxcontainer;
//    }
//}
    //    public int MaxArea(int[] height)
    //    {
    //        var b = new Boolean[height.Length];
    //        for (int i = 0; i < height.Length; i++)
    //        {
    //            b[i] = false;
    //        }

    //        var maxcontainer = 0;
    //        var max = 0;
    //        while (b.Where(x => x == true).Count() < height.Length - 1)
    //        {
    //            var min = 1e9;
    //            var index = 0;
    //            for (int i = 0; i < height.Length; i++)
    //            {
    //                if (min > height[i] && b[i] == false)
    //                {
    //                    min = height[i];
    //                    index = i;
    //                }
    //            }

    //            var tt = findmaxcontain(height, index, b);
    //            maxcontainer = maxcontainer < tt ? tt : maxcontainer;
    //            b[index] = true;
    //        }
    //        return maxcontainer;

    //    }

    //    private int findmaxcontain(int[] height, int index, bool[] b)
    //    {
    //        var value = height[index];
    //        var right = 0;
    //        var left = 0;
    //        var i = height.Length - 1;
    //        var max = 0;
    //        for (int j = 0; j < height.Length; j++)
    //        {
    //            if (j != index && !b[j])
    //            {
    //                var temp = index - j;
    //                if (temp < 0)
    //                {
    //                    temp = temp * -1;
    //                }
    //                max = max < temp ? temp : max;
    //            }
    //        }

    //        return max * value;
    //        //while (i > index)
    //        //{
    //        //    if (b[i])
    //        //    {
    //        //        i--;
    //        //    }
    //        //    else
    //        //    {
    //        //        right = i - index;
    //        //        break;
    //        //    }
    //        //}
    //        //i = 0;
    //        //while (i < index)
    //        //{
    //        //    if (b[i])
    //        //    {
    //        //        i++;
    //        //    }
    //        //    else
    //        //    {
    //        //        left = index - i;
    //        //        break;
    //        //    }
    //        //}
    //        //return right > left ? right * value : left * value; //往後數
    //    }
    //}
}
