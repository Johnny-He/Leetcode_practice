using System;
using System.Collections.Generic;
using System.Linq;
using Leetcode.Leecode;
using Leetcode.Leetcode_medium_;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write(new Leetcode15().ThreeSum2(new int[]{-1, 0, 1, 2, -1, -4}));
           
            Console.Read();

        }


        static bool Palindrome(int n)
        {
            //solution 1
            var array = n.ToString().ToArray();
            var check = true;
            for (int i = 0, j = array.Length; i < array.Length; i++, j--)
            {
                if (array[i] != array[j])
                {
                    check = false;
                }
            }

            return check;
            //solution 2 
            /*   var test = n.ToString().Reverse().ToList();
               var test2 = n.ToString().ToList();
               bool check =true ;
             
               if (test.Count != test2.Count)
               {
                   return false;
               }
   
               for (int i = 0; i < test.Count; i++)
               {
                   if (test[i] != test2[i])
                   {
                       check = false;
                   }
               }
   
               return check;*/
        }

    }
}
