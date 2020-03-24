using Xunit;

namespace SortMethod.Tests
{
    public class SelectionSortTest
    {
        [Fact]
        public void SortedArrayInput_ReturnSelf()
        {
            int[] inputArray = { 1, 2, 3, 4 };
            int[] expected = { 1, 2, 3, 4 };
            SelectionSort.Sort(inputArray);

            for (int i = 0; i < inputArray.Length; i++)
            {
                Assert.Equal(expected[i], inputArray[i]);
            }
        }

        [Fact]
        public void DescendingArrayInput_ReturnAscendingArray()
        {
            int[] inputArray = { 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4 };
            SelectionSort.Sort(inputArray);

            for (int i = 0; i < inputArray.Length; i++)
            {
                Assert.Equal(expected[i], inputArray[i]);
            }
        }

        [Fact]
        public void SingleElementArrayInput_ReturnSelf()
        {
            int[] inputArray = { 1 };
            int[] expected = { 1 };
            SelectionSort.Sort(inputArray);

            for (int i = 0; i < inputArray.Length; i++)
            {
                Assert.Equal(expected[i], inputArray[i]);
            }
        }

        [Fact]
        public void RandomArrayInput_ReturnSortedArray()
        {
            int[] inputArray = { 1, 3, 2, 5, 1};
            int[] expected = { 1, 1, 2, 3, 5 };
            SelectionSort.Sort(inputArray);

            for (int i = 0; i < inputArray.Length; i++)
            {
                Assert.Equal(expected[i], inputArray[i]);
            }
        }
    }
}
