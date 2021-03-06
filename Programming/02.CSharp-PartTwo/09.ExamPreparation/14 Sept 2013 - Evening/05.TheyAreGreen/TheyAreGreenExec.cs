﻿// Task description is in the solution folder
namespace TheyAreGreen
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TheyAreGreenExec
    {
        private static HashSet<string> result = new HashSet<string>();
        private static int numberOfLetters;

        public static void Main()
        {
            numberOfLetters = int.Parse(Console.ReadLine());
            StringBuilder letters = new StringBuilder(numberOfLetters);
            for (int i = 0; i < numberOfLetters; i++)
            {
                letters.Append(Console.ReadLine());
            }

            Permutation(string.Empty, letters.ToString());
            Console.WriteLine(result.Count);
        }

        private static void Permutation(string combinedSoFar, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                if (!result.Contains(combinedSoFar) && combinedSoFar.Length == numberOfLetters)
                {
                    bool isValid = true;
                    for (int i = 0; i < combinedSoFar.Length - 1; i++)
                    {
                        if (combinedSoFar[i].Equals(combinedSoFar[i + 1]))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        result.Add(combinedSoFar);
                    }
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