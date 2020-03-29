using System;
using System.Collections.Generic;
using System.Linq;

namespace edabit
{
    public class SortLearning
    {
        // ~ Insertion sort
        public static void MySort(int[] values)
        {
            // begin from right side
            for (int i = values.Length - 2; i >= 0; i--)
            {
                int indexToInsert = i;
                // from j to Length-1, the array is always sorted
                for (int j = i + 1; j <= values.Length - 1; j++)
                {
                    // "<" for descending sort
                    if (values[indexToInsert] > values[j])
                    {
                        int temp = values[indexToInsert];
                        values[indexToInsert] = values[j];
                        values[j] = temp;
                        indexToInsert++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static void SortArrayByParity(int[] numbers)
        {
            int evenLength = 0, oddLength = 0;

            // i = evenLength + oddLength;
            for (int i = 0; i < numbers.Length; i++)
            {
                int valueOfCurrentNumber = numbers[i];

                if (numbers[i] % 2 == 0)
                {

                    int indexToInsert = 0;
                    while (indexToInsert < evenLength && numbers[i] > numbers[indexToInsert])
                    {
                        indexToInsert++;
                    }

                    for (int j = evenLength + oddLength - 1; j >= indexToInsert; j--)
                    {
                        numbers[j + 1] = numbers[j];
                    }
                    numbers[indexToInsert] = valueOfCurrentNumber;

                    evenLength = evenLength + 1;
                }
                else
                {
                    for (int j = evenLength; j < evenLength + oddLength; j++)
                    {
                        if (numbers[i] <= numbers[j])  // find the index to insert
                        {
                            for (int k = evenLength + oddLength - 1; k >= j; k--)
                            {
                                numbers[k + 1] = numbers[k];
                            }
                            numbers[j] = valueOfCurrentNumber;
                        }
                    }

                    oddLength = oddLength + 1;
                }
            }
        }

        public static void SortByParity(int[] numbers)
        {
            int[] evenNumbers = ExtractEvenNumbers(numbers);
            int[] oddNumbers = ExtractOddNumbers(numbers);

            SelectionSort(evenNumbers);
            SelectionSort(oddNumbers);

            numbers = evenNumbers.Concat(oddNumbers).ToArray();
        }

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

        public static void SelectionSort(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                // find the minimum in remaining array
                int remainMinimumIndex = i;
                for (int j = i + 1; j < values.Length; j++)
                {
                    // ">" for descending sort
                    if (values[j] < values[remainMinimumIndex])
                    {
                        remainMinimumIndex = j;
                    }
                }

                //swap values
                int temp = values[i];
                values[i] = values[remainMinimumIndex];
                values[remainMinimumIndex] = temp;
            }
        }

        public static void BubbleSort(int[] values)
        {
            for (int i = values.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    // remaining largest value is pushed to the right side
                    if (values[j] > values[j + 1]) // "<" for descending sort
                    {
                        int temp = values[j];
                        values[j] = values[j + 1];
                        values[j + 1] = temp;
                    }
                }
            }

        }

        public static void InsertionSort(int[] values)
        {

        }

        public static void MergeSort(int[] values)
        {

        }

        public static void HeapSort(int[] values)
        {

        }

        public static void QuickSort(int[] values)
        {

        }

        public static void RadixSort(int[] values)
        {

        }

        public static void CountingSort(int[] values)
        {

        }

        public static void BucketSort(int[] values)
        {

        }
    }
}