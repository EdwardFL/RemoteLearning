using System;

namespace BoxingVsUnboxing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Time performance of the sum of 1000 int items from a list: " +
                    ValueTypesBoxingAndUnboxing.TestValueTypesWithoutBoxing(1000));
                Console.WriteLine("Time performance of the sum of 1000 boxed int items from a list: " +
                    ValueTypesBoxingAndUnboxing.TestValueTypesWithBoxing(1000));
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Time performance of retrieving string items from a list : " +
                    ReferenceTypesBoxingAndUnboxing.TestReferenceTypesWithoutBoxing(1000));
                Console.WriteLine("Time performance of retrieving string items from a list of objects (Boxing) : " +
                    ReferenceTypesBoxingAndUnboxing.TestReferenceTypesWithBoxing(1000));
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Time performance of the sum of 100000 int items from a list: " +
                    ValueTypesBoxingAndUnboxing.TestValueTypesWithoutBoxing(100000));
                Console.WriteLine("Time performance of the sum of 100000 boxed int items from a list: " +
                    ValueTypesBoxingAndUnboxing.TestValueTypesWithBoxing(100000));
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Time performance of retrieving string items from a list : " +
                    ReferenceTypesBoxingAndUnboxing.TestReferenceTypesWithoutBoxing(100000));
                Console.WriteLine("Time performance of retrieving string items from a list of objects (Boxing) : " +
                    ReferenceTypesBoxingAndUnboxing.TestReferenceTypesWithBoxing(100000));
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Time performance of the sum of 1000000 int items from a list: " +
                    ValueTypesBoxingAndUnboxing.TestValueTypesWithoutBoxing(1000000));
                Console.WriteLine("Time performance of the sum of 1000000 boxed int items from a list: " +
                    ValueTypesBoxingAndUnboxing.TestValueTypesWithBoxing(1000000));
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Time performance of retrieving string items from a list : " +
                    ReferenceTypesBoxingAndUnboxing.TestReferenceTypesWithoutBoxing(1000000));
                Console.WriteLine("Time performance of retrieving string items from a list of objects (Boxing) : " +
                    ReferenceTypesBoxingAndUnboxing.TestReferenceTypesWithBoxing(1000000));
            }
            Console.ReadKey();
        }
    }
}