using System;
using System.Collections;

namespace edabit
{
    class Program
    {
        static void Main(string[] args)
        {
            //int input = 88488;
            //Console.WriteLine("{1} is {0}", AlgoMethods.IsPalindrome(input), input);

            //int[] testSumSmallest = { -1, -1, 1, 1 };
            //Console.WriteLine(AlgoMethods.SumSmallest2(testSumSmallest));


            //string str = "apedhvkx";
            //Console.WriteLine(AlgoMethods.IsIsogram(str));

            //Console.WriteLine(AlgoMethods.SockPairs("AA"));

            //Console.WriteLine(AlgoMethods.StringTransform("A1B3"));

            //Console.WriteLine(AlgoMethods.MysteryFunc(24));

            //Console.WriteLine(AlgoMethods.PalindromeDescendant(9735));

            /*for (int i = 0; i<=200; i++){
                Console.WriteLine("{0}, {1}",i, AlgoMethods.IsPrime2(i));
            }*/


            // AlgoMethods.LengthOfLongestSubstring1("1234567");

            // int[] myValues = { 10, 1, 3, 5, 23, 4, 3, 6, 8, 3, 2 };

            // SortLearning.MySort(myValues);
            // foreach (int value in myValues)
            // {
            //     Console.WriteLine(value);
            // }


            // // 0.1 * 0.001 = 0.0001;
            // // 0 + 0 = 0.
            // // 0 * 12 = 0.
            // // "" => 0
            // // .12 + .901 = 1.021
            // // .12 * .901 = 0.10812

            // BigNumber n1 = new BigNumber(".1");
            // BigNumber n2 = new BigNumber(".001");

            // BigNumber r = n1 * n2;
            // Console.WriteLine(r);


            // // {1}, 1  => [0,0]
            // // {3}, 1  => [-1,-1]
            // // {1,1}, 1 => [0,1]
            // // {1,1,2}, 1 =>  [0,1]
            // // {0,0,1,2}, 1 => [2,2]
            // // {0,1,1,1,2}, 1 => [1,3]
            // // {0,0,0,1}, 1 => [3,3]
            // // {1,1,2,3,3,4}, 5 => [-1,-1]
            // // {1,1,2,3,3,4}, 0 => [-1,-1]
            // // {1,1,2,3,3,5}, 4 => [-1,-1]
            // int[] ans = AlgoMethods.SearchRange(new int[] {1,1}, 1);

            // foreach(var an in ans){
            //     Console.WriteLine(an);
            // }

            int[] ans = {3,2,1,6,4};
            SortLearning.SortArrayByParity(ans);

            foreach(var an in ans)
            {
                Console.WriteLine(an);
            }

        }

    }
}