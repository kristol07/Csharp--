using Xunit;

namespace SortMethod.Tests
{
    public class SortByParityTest
    {
        [Theory]
        [InlineData(new int[] { 1, 1, 2, 3, 1 })]
        [InlineData(new int[] { 1, 3, 2, 1, 1 })]
        [InlineData(new int[] { 2, 3, 1, 1, 1 })]
        public void ReturnSortedArrayByParity(int[] inputArray)
        {
            int[] expected = new int[] { 2, 1, 1, 1, 3 };
            int[] result = SortByParity.Sort(inputArray);

            Assert.Equal(expected, result);
        }
    }
}
