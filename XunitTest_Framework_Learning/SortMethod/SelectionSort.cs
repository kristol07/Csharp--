using System;

namespace SortMethod
{
    public class SelectionSort
    {
       public static void Sort(int[] values)
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
    }
}