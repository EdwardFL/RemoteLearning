using System.Collections.Generic;
using System.Diagnostics;

namespace BoxingVsUnboxing
{
    internal class ValueTypesBoxingAndUnboxing
    {
        public static long TestValueTypesWithoutBoxing(int value)
        {
            Stopwatch timer;
            timer = Stopwatch.StartNew();

            List<int> unboxedValuesList = new List<int>();

            for (int i = 0; i < value; i++)
            {
                unboxedValuesList.Add(i);
            }

            int sumOfRetrivedValues = 0;
            foreach (var items in unboxedValuesList)
            {
                sumOfRetrivedValues += items;
            }
            timer.Stop();
            return timer.ElapsedTicks;
        }

        public static long TestValueTypesWithBoxing(int value)
        {
            Stopwatch timer;
            timer = Stopwatch.StartNew();

            List<object> boxedValuesList = new List<object>();

            for (int i = 0; i < value; i++)
            {
                boxedValuesList.Add(i);
            }

            int sumOfRetrivedValues = 0;
            foreach (var items in boxedValuesList)
            {
                sumOfRetrivedValues += (int)items;
            }
            timer.Stop();
            return timer.ElapsedTicks;
        }
    }
}