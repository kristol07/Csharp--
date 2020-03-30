namespace CsharpConcepts
{
    class ListExample
    {

        public void Init()
        {

            // dimension => type
            int[,] listTest;

            // length => initialization
            listTest = new int[2, 1];
            listTest = new [,] { { 0, 1, 1 }, { 2, 3, 4 } };


            // jagged array
            int [][] jagArr;
            jagArr = new int[2][]; // only upper level allowed

            // create individually
            jagArr[0] = new int[] {0,1};
            jagArr[1] = new int[] {2,6,7};

        }

    }
}