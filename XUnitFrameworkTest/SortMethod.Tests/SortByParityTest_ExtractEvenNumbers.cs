using Xunit;

namespace SortMethod.Tests
{
    public class ExtractEvenNumbersTest
    {

        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 3 })]
        [InlineData(new int[] { 1, 1 })]
        public void NoEvenNumbersInput_ReturnEmptyArray(int[] inputArray)
        {
            int[] expected = new int[] { };
            int[] result = SortTool.ExtractEvenNumbers(inputArray);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 2 })]
        [InlineData(new int[] { 2, 4 })]
        [InlineData(new int[] { 2, 2 })]
        [InlineData(new int[] { 2, 4, 2 })]
        public void EvenNumbersInput_ReturnSelf(int[] inputArray)
        {
            int[] expected = inputArray;
            int[] result = SortTool.ExtractEvenNumbers(inputArray);

            for(int i = 0; i < inputArray.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 2 }, new int[] { 1, 2 })]
        [InlineData(new int[] { 2, 4 }, new int[] { 1, 2, 4 })]
        [InlineData(new int[] { 2, 2 }, new int[] { 1, 2, 2 })]
        [InlineData(new int[] { 2, 4, 2 }, new int[] { 1, 3, 2, 4, 2 })]
        public void ExtractEvenNumbers_ReturnOnlyEvenNumbers(int[] expected, int[] inputArray)
        {
            int[] result = SortTool.ExtractEvenNumbers(inputArray);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
    }
}