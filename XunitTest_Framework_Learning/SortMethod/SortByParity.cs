using System;
using System.Collections.Generic;
using System.Linq;

namespace SortMethod
{
    public class SortByParity
    {
        public static int[] Sort(int[] numbers)
        {
            int[] evenNumbers = SortTool.ExtractEvenNumbers(numbers);
            int[] oddNumbers = SortTool.ExtractOddNumbers(numbers);

            SelectionSort.Sort(evenNumbers);
            SelectionSort.Sort(oddNumbers);

            return evenNumbers.Concat(oddNumbers).ToArray();
        }
    }
}