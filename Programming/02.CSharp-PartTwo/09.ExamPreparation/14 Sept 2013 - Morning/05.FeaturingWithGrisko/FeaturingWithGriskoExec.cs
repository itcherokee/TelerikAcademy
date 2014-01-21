// Task description is in the solution folder
namespace FeaturingWithGrisko
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FeaturingWithGriskoExec
    {
        private static HashSet<string> result = new HashSet<string>();
        private static int numberOfLetters;

        public static void Main()
        {
            string letters = Console.ReadLine();
            numberOfLetters = letters.Length;
            Permutation(string.Empty, letters);
            Console.WriteLine(result.Count);
        }

        private static void Permutation(string combinedSoFar, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                if (!result.Contains(combinedSoFar) && combinedSoFar.Length == numberOfLetters)
                {
                    // bool isValid = true;
                    // for (int i = 0; i < soFar.Length - 1; i++)
                    // {
                    //    if (soFar[i].Equals(soFar[i + 1]))
                    //    {
                    //        isValid = false;
                    //        break;
                    //    }
                    // }

                    // if (isValid)
                    // {
                    result.Add(combinedSoFar);

                    // }
                }

                return;
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (combinedSoFar.Length > 0 && combinedSoFar[combinedSoFar.Length - 1].Equals(input[i]))
                    {
                        continue;
                    }

                    string remaining = input.Substring(0, i) + input.Substring(i + 1);
                    Permutation(combinedSoFar + input[i], remaining);
                }
            }
        }
    }
}