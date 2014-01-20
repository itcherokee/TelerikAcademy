// Task description is in the solution folder
namespace TheyAreGreen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TheyAreGreenExec
    {
        private static int result = 0;
        private static List<byte> letters;

        public static void Main()
        {
            int numberOfLetters = int.Parse(Console.ReadLine());
            letters = new List<byte>(numberOfLetters);
            for (int i = 0; i < numberOfLetters; i++)
            {
                letters.Add((byte)(Console.ReadLine()[0] - 97));
            }

            letters.Sort();
            int index = 0;
            // for (int index = 1; index <= upperBound; index++)
            while (index < letters.Count)
            {
                var permutation = new List<int>();
                permutation.Add(letters[index]);
                Permutate(permutation, letters.Count);
                index++;
            }

            Console.WriteLine(result);
        }

        /// <summary>
        /// Calculating permutation by permutation.
        /// </summary>
        /// <param name="permutation">An array holding current permutation under construction.</param>
        /// <param name="size">The upper bound of range with numbers for permutations.</param>
        private static void Permutate(List<int> permutation, int size)
        {
            // When size of current array holding permutation under construction reach the upped bound of number's range we set,
            // we are ready with current permutaion and output it to Console without keeping it in another array.
            // After that we return from current recursion level one step back and start the construction of next permutation.
            if (permutation.Count == size)
            {
                result++;
                  Console.Write("{" + string.Join(",", permutation) + "} ");
                return;
            }

            for (int number = 0; number < size; number++)
            {
                // Check does current number has been used already in the current constructing permutation record
                // bool sameNeighbour = false;
                bool sameNeighbour = false;
                if (permutation.Count >= 1 && permutation[permutation.Count - 1] == letters[number])
                {
                    sameNeighbour = true;
                    //  break;
                }
                //for (int i = 0; i < permutation.Count; i++)
                //{
                //    if (letters[number] == permutation[i])
                //    {
                //        // already used number in single permutation found, so we skip it
                //        sameNeighbour = true;
                //        break;
                //    }
                //}

                // If current number is not found to be used up to now, we add it the to current permutation
                // and continue digging by calling the same method (recursivly)
                if (!sameNeighbour)
                {
                    var onePermutation = new List<int>(permutation);
                    onePermutation.Add(letters[number]);
                    Permutate(onePermutation, size);
                }
            }
        }

    }


}
