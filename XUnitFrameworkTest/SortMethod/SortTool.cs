using System;
using System.Collections.Generic;
using System.Linq;

namespace SortMethod
{
    public class SortTool
    {
        public static int[] ExtractEvenNumbers(int[] numbers)
        {
            List<int> evenList = new List<int>();

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenList.Add(number);
                }
            }

            return evenList.ToArray();
        }

        public static int[] ExtractOddNumbers(int[] numbers)
        {
            List<int> OddList = new List<int>();

            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    OddList.Add(number);
                }
            }

            return OddList.ToArray();
        }        
    }
}