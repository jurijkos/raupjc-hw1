﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonzolnaAplikacija2
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        private static void ListExample(IIntegerList listOfIntegers)
        {
          
            listOfIntegers.Add(2); // [1,2] 
            listOfIntegers.Add(3); // [1,2,3] 
            listOfIntegers.Add(4); // [1,2,3,4] 
            listOfIntegers.Add(5); // [1,2,3,4,5]
            listOfIntegers.RemoveAt(0); // [2,3,4,5] 
            listOfIntegers.Remove(5); //[2,3,4]
            Console.WriteLine(listOfIntegers.Count); // 3 
            Console.WriteLine(listOfIntegers.Remove(100)); // false Console.WriteLine(listOfIntegers.RemoveAt(5)); // false 
            listOfIntegers.Clear(); // [] 
            Console.WriteLine(listOfIntegers.Count); // 0
            listOfIntegers.Add(1); // [1] 
            
        }
    }
}
