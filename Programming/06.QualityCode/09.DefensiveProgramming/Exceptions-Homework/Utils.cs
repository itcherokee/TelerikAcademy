namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Utils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (startIndex + count > arr.Length)
            {
                throw new ArgumentOutOfRangeException("Subsequence", "\"StartIndex\" + \"count\" are greater than \"arr\" length!");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length - 1)
            {
                throw new ArgumentOutOfRangeException("ExtractEnding", "\"count\" is bigger then \"str\" length!");
            }

            if (str == null)
            {
                throw new ArgumentNullException("ExtractEnding", "\"str\" can not be null!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            if (number < 2)
            {
                throw new ArgumentOutOfRangeException("CheckPrime - number", "Only numbers bigger than 1 could be prime!");
            }

            int sqrt = (int)Math.Sqrt(number);
            for (int divisor = 2; divisor <= sqrt; divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
