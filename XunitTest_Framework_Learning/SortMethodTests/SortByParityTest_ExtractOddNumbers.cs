using Xunit;


namespace SortMethod.Tests
{
    public class ExtractOddNumbersTest
    {

        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 3 })]
        [InlineData(new int[] { 1, 1 })]
        public void NoOddNumbersInput_ReturnEmptyArray(int[] inputArray)
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
        public void OddNumbersInput_ReturnSelf(int[] inputArray)
        {
            int[] expected = inputArray;
            int[] result = SortTool.ExtractEvenNumbers(inputArray);

            Assert.True(SelectionSortTest.IsSameArray(expected, result));
        }


        [Theory]
        [InlineData(new int[] { 1 }, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 1 }, new int[] { 1, 2, 1 })]
        [InlineData(new int[] { 1, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 3, 1 }, new int[] { 1, 3, 2, 4, 1 })]
        public void ExtractOddNumbers_ReturnOnlyOddNumbers(int[] expected, int[] inputArray)
        {
            int[] result = SortTool.ExtractOddNumbers(inputArray);

            Assert.True(SelectionSortTest.IsSameArray(expected, result));
        }
    }
}