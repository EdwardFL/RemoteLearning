using System.Collections.Generic;
using System.Diagnostics;

namespace BoxingVsUnboxing
{
    internal class ReferenceTypesBoxingAndUnboxing
    {
        public static long TestReferenceTypesWithBoxing(int value)
        {
            Stopwatch timer;
            timer = Stopwatch.StartNew();

            string[] strList = new string[value];
            List<object> unboxedValuesList = new List<object>();

            for (int i = 0; i < value; i++)
            {
                unboxedValuesList.Add(strList[i]);
            }
            string s;
            foreach (var t in unboxedValuesList)
            {
                s = (string)t;
            }

            timer.Stop();
            return timer.ElapsedTicks;
        }

        public static long TestReferenceTypesWithoutBoxing(int value)
        {
            Stopwatch timer;
            timer = Stopwatch.StartNew();

            string[] strList = new string[value];
            List<string> unboxedValuesList = new List<string>();

            for (int i = 0; i < value; i++)
            {
                unboxedValuesList.Add(strList[i]);
            }
            string s;
            foreach (var t in unboxedValuesList)
            {
                s = t;
            }

            timer.Stop();
            return timer.ElapsedTicks;
        }
    }
}