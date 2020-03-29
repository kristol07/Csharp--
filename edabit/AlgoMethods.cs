using System;

namespace edabit
{
    public class AlgoMethods
    {
        public static bool IsPalindrome(int number)
        {
            string strOfNumber = number.ToString();
            for (int i = 0; i <= strOfNumber.Length / 2; i++)
            {
                if (strOfNumber[i] != strOfNumber[strOfNumber.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int SumSmallest(int[] values)
        {
            int s1 = -1, s2 = -1;
            foreach (int val in values)
            {
                if (val >= 0)
                {
                    if (s1 < 0)
                    {
                        s1 = val;
                        continue;
                    }

                    if (s1 <= val)
                    {
                        if (s2 < 0)
                        {
                            s2 = s1;
                            s1 = val;
                            continue;
                        }
                        continue;
                    }

                    if (s1 > val)
                    {
                        if (s2 < 0)
                        {
                            s2 = val;
                            continue;
                        }

                        if (val > s2)
                        {
                            s1 = val;
                        }
                        else
                        {
                            s1 = s2;
                            s2 = val;
                        }
                    }

                }

            }

            // Console.WriteLine("{0}, {1}", s1, s2);
            return s1 + s2;

        }

        public static int SumSmallest2(int[] values)
        {
            int min1 = int.MaxValue, min2 = int.MaxValue;

            foreach (int val in values)
            {
                if (val >= 0 && val <= min2)
                {
                    if (val <= min1)
                    {
                        min2 = min1;
                        min1 = val;
                    }
                    else
                    {
                        min2 = val;
                    }
                }
            }

            return min1 + min2;
        }



        // "ABAC" => false;
        // "ACB" => true;
        public static bool IsIsogram(string str)
        {

            int[] charCount = new int[26];

            // (int) ('A') = 65
            foreach (char charOfStr in str)
            {
                if (charCount[char.ToUpper(charOfStr) - 65] == 0)
                {
                    charCount[char.ToUpper(charOfStr) - 65] += 1;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        // (3,5) => [3,6,9,12,15]
        // (2,3) => [2,4,6]
        public static int[] ArrayOfMultiples(int number, int length)
        {
            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = number * (i + 1);
            }

            return result;
        }

        public static bool IsPrime(int x)
        {
            if (x == 2 || x == 3) { return true; }
            if (x <= 1 || x % 2 == 0) { return false; }

            for (int i = 3; i <= (int)Math.Sqrt(x); i = i + 2)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        public static bool IsPrime2(int x)
        {
            if (x <= 1) { return false; }
            if (x == 2 || x == 3) { return true; }

            if (x % 6 != 1 && x % 6 != 5) { return false; }

            for (int i = 5; i <= Math.Sqrt(x); i = i + 6)
            {
                if (x % i == 0 || x % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // "ABCCCBBA" => 3
        // "AABCB" => 2
        public static int SockPairs(string socks)
        {
            if (string.IsNullOrEmpty(socks)) { return 0; }

            int SockPairs = 0;
            int[] sockCount = new int[26];

            foreach (char sock in socks)
            {
                sockCount[sock - 'A'] += 1;

                if (sockCount[sock - 'A'] == 2)
                {
                    SockPairs += 1;
                    sockCount[sock - 'A'] = 0;
                }

            }

            return SockPairs;
        }


        // "A1B2C3" => "ABBCCC"
        public static string StringTransform(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i = i + 2)
            {
                // (int)'1' = 49;
                result += new string(str[i], str[i + 1] - 48);  // Convert.ToInt32(); (int) 'char';
                /*
                for (int j = 0; j < str[i + 1] - 48; j++)  
                {
                    result += str[i];
                }
                */
            }

            return result;
        }

        public static int MysteryFunc(int number)
        {
            int result = 0, part = 2, leastNum = 1, temp = number;

            while (temp / 2 != 0)
            {
                result += (part * 10);
                leastNum *= 2;
                temp /= 2;
                part *= 10;

            }

            result += (number - leastNum);

            return result;

        }


        // 9 -> 2221
        // 17 -> 22221
        // 24 -> 22228
        public static long MysteryFunc2(int number)
        {
            int result = 0, leastNum = 1;

            while (number > leastNum * 2)
            {
                result = result * 10 + 2;
                leastNum = leastNum * 2;
            }

            return result * 10 + number % leastNum;
        }

        public static bool PalindromeDescendant(int number)
        {
            return false;
        }

        public static int LengthOfLongestSubstring2(string str)
        {
            if (string.IsNullOrEmpty(str)) { return 0; }

            // save all longest substring begining from each char
            string[] result = new string[str.Length];
            int countOfLongestSubstring = 0, lengthOfLongestSubstring = 1;
            int moveSize = 1;

            string longestSubstring = Char.ToString(str[0]), nextLongestSubstring = "";

            for (int i = 0; i < str.Length; i += moveSize)
            {
                // find the longest substring begining from current char
                for (int j = i + longestSubstring.Length; j < str.Length; j++)
                {
                    if (!longestSubstring.Contains(str[j]))
                    {
                        longestSubstring += Char.ToString(str[j]);
                    }
                    else
                    {
                        nextLongestSubstring = longestSubstring.Substring(
                                            longestSubstring.IndexOf(str[j]) + 1)
                                            + Char.ToString(str[j]);
                        break;
                    }
                }

                // save substring with same or larger length
                if (longestSubstring.Length >= lengthOfLongestSubstring)
                {
                    // new longer substring appears, renew count
                    if (longestSubstring.Length > lengthOfLongestSubstring)
                    {
                        countOfLongestSubstring = 0;
                    }

                    result[countOfLongestSubstring] = longestSubstring;
                    countOfLongestSubstring += 1;
                    lengthOfLongestSubstring = longestSubstring.Length;
                }

                moveSize = longestSubstring.Length - nextLongestSubstring.Length + 1;
                longestSubstring = nextLongestSubstring;

            }

            Console.WriteLine("The number of longest substring is {0}:",
                                                countOfLongestSubstring);
            for (int i = 0; i < countOfLongestSubstring; i++)
            {
                Console.WriteLine(result[i]);
            }

            return lengthOfLongestSubstring;
        }


        public static int LengthOfLongestSubstring1(string str)
        {
            if (string.IsNullOrEmpty(str)) { return 0; }

            // save all longest substring begining from each char
            string[] result = new string[str.Length];
            int countOfLongestSubstring = 0, lengthOfLongestSubstring = 1;

            for (int i = 0; i < str.Length; i++)
            {
                string longestSubstring = Char.ToString(str[i]);

                // find the longest substring begining from current char
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (!longestSubstring.Contains(str[j]))
                    {
                        longestSubstring += Char.ToString(str[j]);
                    }
                    else
                    {
                        break;
                    }
                }

                // save substring with same or larger length
                if (longestSubstring.Length >= lengthOfLongestSubstring)
                {
                    // new longer substring appears, renew count
                    if (longestSubstring.Length > lengthOfLongestSubstring)
                    {
                        countOfLongestSubstring = 0;
                    }

                    result[countOfLongestSubstring] = longestSubstring;
                    countOfLongestSubstring += 1;
                    lengthOfLongestSubstring = longestSubstring.Length;
                }
            }

            Console.WriteLine("The number of longest substring is {0}:",
                                                countOfLongestSubstring);
            for (int i = 0; i < countOfLongestSubstring; i++)
            {
                Console.WriteLine(result[i]);
            }

            return lengthOfLongestSubstring;
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            int startIndex = -1, endIndex = -1;

            if(nums is null)
            {
                throw new System.ArgumentNullException("nums is null, invalid!!!");
            }

            // nums is not valid && target is out of range 
            if (nums.Length == 0 || nums[0] > target || nums[nums.Length - 1] < target)
            {
                return new int[] { -1, -1 };
            }

            int start = 0, end = nums.Length - 1;
            int middle;

            while (end > start)
            {
                middle = (end - start) / 2 + start;
                if (nums[middle] >= target)
                {
                    end = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }

            if (nums[start] == target)
            {
                startIndex = start;
            }
            else
            {
                // can not find the target
                return new int[] { -1, -1 };
            }

            // find the right side of range
            // no need to renew start
            end = nums.Length - 1;

            while (end > start)
            {
                middle = (end - start) / 2 + start + 1; // "+1" is important
                if (nums[middle] <= target)
                {
                    start = middle;
                }
                else
                {
                    end = middle - 1;
                }

            }

            endIndex = end;

            return new int[] { startIndex, endIndex };

        }

        public static int[] SearchRange2(int[] nums, int target)
        {
            int startIndex = -1, endIndex = -1;

            if (nums.Length == 0 || nums[0] > target || nums[nums.Length - 1] < target)
            {
                return new int[] { startIndex, endIndex };
            }

            int start = 0, end = nums.Length - 1;
            int middle;

            while (end > start + 1)
            {
                middle = (end - start) / 2 + start;
                if (nums[middle] >= target)
                {
                    if (nums[middle] == target && nums[middle - 1] != target)
                    {
                        startIndex = middle;
                        break;
                    }
                    end = middle;
                }
                else
                {
                    start = middle;
                }
            }

            if (end - start <= 1)
            {
                startIndex = nums[start] == target
                            ? start
                            : (nums[end] == target ? end : -1);
            }

            start = 0;
            end = nums.Length - 1;

            while (end > start + 1)
            {
                middle = (end - start) / 2 + start + 1;
                if (nums[middle] <= target)
                {
                    if (nums[middle] == target && nums[middle + 1] != target)
                    {
                        endIndex = middle;
                        break;
                    }
                    start = middle;
                }
                else
                {
                    end = middle;
                }

            }

            if (end - start <= 1)
            {
                endIndex = nums[end] == target
                            ? end
                            : (nums[start] == target ? start : -1);
            }

            return new int[] { startIndex, endIndex };

        }
    }
}