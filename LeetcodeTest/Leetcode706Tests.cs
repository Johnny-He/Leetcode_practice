using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode706Test
    {
        [Test]
        public void test()
        {   
            
       
            
        }
    }

    public class LeetCode706
    {
        
    }
    public class MyHashMap
    {
        private readonly Dictionary<int,int> MyHashMapLookup = new Dictionary<int, int>();
        public MyHashMap() {
                    
        }
    
        public void Put(int key, int value)
        {
            if (!MyHashMapLookup.TryAdd(key,value))
            {
                MyHashMapLookup[key] = value;
            }
        }
    
        public int Get(int key)
        {
            if (!MyHashMapLookup.TryGetValue(key, out var value))
            {
                return -1;
            }
            return value;
        }
    
        public void Remove(int key)
        {
            MyHashMapLookup.Remove(key);
        }
    }

  
}