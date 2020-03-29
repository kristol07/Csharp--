using System;

namespace BigNumberCal
{
    public class BigNumber
    {
        public string Value
        {
            get; set;
        }

        public BigNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Value = "0";
            }
            else
            {
                Value = value;
            }

        }

        public BigNumber(double value)
        {
            Value = value.ToString();
        }

        public static BigNumber IntegerAdd_OLD(BigNumber number1, BigNumber number2)
        {
            char[] str1 = number1.Value.ToCharArray(),
                    str2 = number2.Value.ToCharArray();

            Array.Reverse(str1); Array.Reverse(str2);
            if (str1.Length < str2.Length)
            {
                char[] temp = str1;
                str1 = str2;
                str2 = temp;
            }

            char[] charOfResult = new char[str1.Length + 1];

            int hold = 0;

            for (int i = 0; i < charOfResult.Length; i++)
            {
                if (i == str1.Length)
                {
                    charOfResult[i] = (char)(hold + '0');  // ?????????
                    break;
                }

                if (i >= str2.Length)
                {
                    hold = hold + (int)Char.GetNumericValue(str1[i]);
                }
                else
                {
                    hold = hold + (int)Char.GetNumericValue(str1[i]) + (int)Char.GetNumericValue(str2[i]);
                }
                charOfResult[i] = (char)(hold % 10 + '0');  // ?????????
                hold = hold / 10;
            }

            Array.Reverse(charOfResult);

            string resultString = new string(charOfResult);
            if (charOfResult[0] == '0')
            {
                resultString = resultString.Substring(1);
            }

            return new BigNumber(resultString);

        }

        public static BigNumber IntegerAdd(BigNumber number1, BigNumber number2)
        {
            int lengthOfResult = Math.Max(number1.Value.Length, number2.Value.Length) + 1;

            char[] number1Chars = number1.Value.PadLeft(lengthOfResult, '0').ToCharArray();
            char[] number2Chars = number2.Value.PadLeft(lengthOfResult, '0').ToCharArray();

            char[] resultChars = new char[lengthOfResult];

            int carry = 0;

            for (int i = lengthOfResult - 1; i >= 0; i--)
            {
                carry = carry + (number1Chars[i] - '0') + (number2Chars[i] - '0');
                resultChars[i] = (char)(carry % 10 + '0');
                carry = carry / 10;
            }

            string resultString = new string(resultChars).TrimStart('0');

            return new BigNumber(resultString);

        }


        public static BigNumber Add(BigNumber number1, BigNumber number2)
        {
            if (!number1.Value.Contains("."))
            {
                number1 = new BigNumber(number1.Value + ".0");
            }
            if (!number2.Value.Contains("."))
            {
                number2 = new BigNumber(number2.Value + ".0");
            }

            string num1DecimalString = number1.Value.Split('.')[1];
            string num2DecimalString = number2.Value.Split('.')[1];
            int lengthOfResultDecimal = Math.Max(num1DecimalString.Length, num2DecimalString.Length);

            BigNumber num1Decimal = new BigNumber(num1DecimalString.PadRight(lengthOfResultDecimal, '0'));
            BigNumber num2Decimal = new BigNumber(num2DecimalString.PadRight(lengthOfResultDecimal, '0'));

            BigNumber num1Integer = new BigNumber(number1.Value.Split('.')[0]);
            BigNumber num2Integer = new BigNumber(number2.Value.Split('.')[0]);

            BigNumber integerResult = BigNumber.IntegerAdd(num1Integer, num2Integer);
            BigNumber decimalResult = BigNumber.IntegerAdd(num1Decimal, num2Decimal);

            if (decimalResult.Value.Length > lengthOfResultDecimal)
            {
                decimalResult.Value = decimalResult.Value.Substring(1);
                integerResult = BigNumber.IntegerAdd(integerResult, new BigNumber("1"));
            }

            string resultString = integerResult.Value + "." + decimalResult.Value;

            return new BigNumber(resultString.TrimEnd('0'));

        }

        public static BigNumber IntegerMultiply_OLD(BigNumber number1, BigNumber number2)
        {

            char[] str1 = number1.Value.ToCharArray();
            char[] str2 = number2.Value.ToCharArray();
            char[] resultChars = new char[number1.Value.Length + number2.Value.Length];

            Array.Reverse(str1); Array.Reverse(str2);

            BigNumber hold = new BigNumber("0");

            for (int i = 0; i < resultChars.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j < str1.Length && (i - j) < str2.Length)
                    {
                        double valueOfHold = Char.GetNumericValue(str1[j]) * Char.GetNumericValue(str2[i - j]);
                        hold = BigNumber.IntegerAdd(hold, new BigNumber(valueOfHold.ToString()));
                    }
                }

                if (i != resultChars.Length - 1 || hold.Value.Length != 0)
                {
                    resultChars[i] = hold.Value.ToCharArray()[hold.Value.Length - 1];
                    hold = new BigNumber(hold.Value.Remove(hold.Value.Length - 1));
                }

            }

            Array.Reverse(resultChars);

            string resultString = new string(resultChars);
            if (resultChars[0] == '\0')
            {
                resultString = resultString.Substring(1);
            }

            return new BigNumber(resultString);
        }

        public static BigNumber IntegerMultiply(BigNumber number1, BigNumber number2)
        {
            char[] number1Chars = number1.Value.ToCharArray();
            char[] number2Chars = number2.Value.ToCharArray();
            char[] resultChars = new string('0', number1Chars.Length + number2Chars.Length).ToCharArray();

            int tempSum;
            for (int i = number1Chars.Length - 1; i >= 0; i--)
            {
                for (int j = number2Chars.Length - 1; j >= 0; j--)
                {
                    tempSum = resultChars[i + j + 1] - '0' + (number1Chars[i] - '0') * (number2Chars[j] - '0');
                    resultChars[i + j] = (char)(resultChars[i + j] + tempSum / 10);
                    resultChars[i + j + 1] = (char)(tempSum % 10 + '0');
                }
            }

            string resultString = new string(resultChars).TrimStart('0');

            return new BigNumber(resultString);
        }

        public static BigNumber Multiply(BigNumber number1, BigNumber number2)
        {
            if (!number1.Value.Contains("."))
            {
                number1 = new BigNumber(number1.Value + ".0");
            }
            if (!number2.Value.Contains("."))
            {
                number2 = new BigNumber(number2.Value + ".0");
            }

            int indexOfDotInNumber1 = number1.Value.IndexOf('.');
            int indexOfDotInNumber2 = number2.Value.IndexOf('.');

            int exponential1 = number1.Value.Length - indexOfDotInNumber1 - 1;
            int exponential2 = number2.Value.Length - indexOfDotInNumber2 - 1;

            string baseString1 = number1.Value.Remove(indexOfDotInNumber1)
                                + number1.Value.Substring(indexOfDotInNumber1 + 1);

            string baseString2 = number2.Value.Remove(indexOfDotInNumber2)
                                + number2.Value.Substring(indexOfDotInNumber2 + 1);

            string resultBaseString = BigNumber.IntegerMultiply(
                                                    new BigNumber(baseString1),
                                                    new BigNumber(baseString2)).Value;

            int lengthOfResult = resultBaseString.Length > exponential1 + exponential2
                                                        ? resultBaseString.Length
                                                        : exponential1 + exponential2 + 1;
            resultBaseString = resultBaseString.PadLeft(lengthOfResult, '0');

            int indexofDotInResult = resultBaseString.Length - exponential1 - exponential2;
            string resultString = resultBaseString.Remove(indexofDotInResult)
                                                    + "."
                                                    + resultBaseString.Substring(indexofDotInResult);

            return new BigNumber(resultString.TrimEnd('0'));

        }

        public static BigNumber operator +(BigNumber x, BigNumber y)
        {
            return BigNumber.Add(x, y);
        }

        public static BigNumber operator *(BigNumber x, BigNumber y)
        {
            return BigNumber.Multiply(x, y);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}