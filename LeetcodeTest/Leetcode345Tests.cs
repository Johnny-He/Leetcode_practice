using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeTest;

[TestFixture]
public class LeetCode605Tests
{
    [Test]
    public void can_place_flowers()
    {
        var leetCode605 = new LeetCode605();
        var canPlaceFlowers = leetCode605.CanPlaceFlowers2([0,0,1,0,1], 1);
        // var canPlaceFlowers = leetCode605.CanPlaceFlowers([0, 0, 1, 0, 1], 1);
        canPlaceFlowers.Should().BeTrue();
    }
}

public class LeetCode605
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        var maxCanPlaceFlowers = 0;
        var temp = 0;
        var tempArray1 = new int[flowerbed.Length + 1];
        if (flowerbed[0] == 0)
        {
            tempArray1[0] = 0;
            for (var i = 1; i < tempArray1.Length; i++)
            {
                tempArray1[i] = flowerbed[i - 1];
            }
        }
        else
        {
            tempArray1 = flowerbed;
        }

        var tempArray2 = new int[tempArray1.Length + 1];
        if (tempArray1[tempArray1.Length - 1] == 0)
        {
            tempArray2[tempArray2.Length - 1] = 0;
            for (var i = 0; i < tempArray2.Length - 1; i++)
            {
                tempArray2[i] = tempArray1[i];
            }
        }
        else
        {
            tempArray2 = tempArray1;
        }

        for (var i = 0; i < tempArray2.Length; i++)
        {
            if (tempArray2[i] == 0)
            {
                temp++;
            }
            else
            {
                if (temp >= 3)
                {
                    maxCanPlaceFlowers += (temp - 1) / 2;
                }

                temp = 0;
            }
        }

        if (temp >= 3)
        {
            maxCanPlaceFlowers += (temp - 1) / 2;
        }

        return maxCanPlaceFlowers >= n;
    }

    public bool CanPlaceFlowers2(int[] flowerbed, int n)
    {
        var maxCanPlaceFlowers = 0;
        var temp = 0;
        if (flowerbed.Length == 1 && flowerbed[0] == 0)
        {
            return n <= 1;
        }
        
        for (var i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0)
            {
                temp++;
                if(i == 0 || i == flowerbed.Length-1)
                {
                    temp++;
                }
            }
            else
            {
                if (temp >= 3)
                {
                    maxCanPlaceFlowers += (temp - 1) / 2;
                }

                temp = 0;
            }
        }

        if (temp >= 3)
        {
            maxCanPlaceFlowers += (temp - 1) / 2;
        }

        return maxCanPlaceFlowers >= n;
    }
}