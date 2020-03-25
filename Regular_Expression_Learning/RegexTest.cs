using System;
using System.Text.RegularExpressions;

namespace RegularExpressionLearning
{
    public class RegexTest
    {
        public static void Test(string[] args)
        {
            // replace strings
            string pattern = @"([a-zA-Z]+) (\d+)";
            string input = "June 24, August 9, Dec 12";
            string replacedString = Regex.Replace(input, pattern, @"$2 of $1");
            Console.WriteLine(replacedString);

            // match & matches
            pattern = @"\b(\w+?)\s\1\b";  // duplicated words
            input = "This this is a nice day, what about this? This tastes good, I saw a a dog.";
            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("{0} (duplicates '{1}') at position {2}", match.Value, match.Groups[1].Value, match.Index);
            }

            //

        }
    }
}