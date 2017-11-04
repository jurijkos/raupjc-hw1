using System;
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
            // IIntegerList list = new IntegerList();
            // list.Add(10);
            // Console.WriteLine(list.GetElement(0));
            // Console.WriteLine(list.Count);
            // list.Add(11);
            // Console.WriteLine(list.GetElement(0));
            // Console.WriteLine(list.GetElement(1));
            // Console.WriteLine(list.Count);
            // list.Clear();
            // list.Add(11);
            // list.Add(2);
            // list.Add(11);
            // Console.WriteLine(list.Remove(10));
            // Console.WriteLine(list.Count);
            // //remove only first occurance
            // list.Remove(11);
            // Console.WriteLine(list.GetElement(1));
            // Console.WriteLine(list.GetElement(0));
            // 
            //
            //
            // list.Clear();
            // list.Add(11);
            // Console.WriteLine(list.RemoveAt(0));
            // Console.WriteLine(list.Count);
            // list.Add(11); list.Add(12); list.Add(13);
            // list.RemoveAt(1);
            // Console.WriteLine(list.GetElement(0) + " " + list.GetElement(1));
            // list.GetElement(100);
            // Console.Read();
            //IIntegerList list = new IntegerList();
            //ListExample(list);

            //test for genricList
            GenericList<String> stringList = new GenericList<string>();
            stringList.Add("Pero");
            Console.WriteLine(stringList.GetElement(0));
            Console.WriteLine(stringList.Count);

            IGenericList<int> list = new GenericList<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(-i);
            }
            foreach (var i in list)
            {
                Console.WriteLine(list.GetElement(-i));
            }
            Console.ReadLine();
        }
        private static void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1);
            listOfIntegers.Add(2); // [1,2] 
            listOfIntegers.Add(3); // [1,2,3] 
            listOfIntegers.Add(4); // [1,2,3,4] 
            listOfIntegers.Add(5); // [1,2,3,4,5]
            listOfIntegers.RemoveAt(0); // [2,3,4,5] 
            listOfIntegers.Remove(5); //[2,3,4]
            Console.WriteLine(listOfIntegers.GetElement(1));
            Console.WriteLine(listOfIntegers.Count); // 3 
            Console.WriteLine(listOfIntegers.Remove(100)); // false Console.WriteLine(listOfIntegers.RemoveAt(5)); // false 
            listOfIntegers.Clear(); // [] 
            Console.WriteLine(listOfIntegers.Count); // 0
            listOfIntegers.Add(1); // [1] 
            Console.Read();
            
        }
    }
}
